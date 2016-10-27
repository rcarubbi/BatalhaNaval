using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BatalhaNaval.Services;
using System.Drawing;

namespace BatalhaNaval.Services.Implementation
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant, InstanceContextMode = InstanceContextMode.Single)]
    public class NavalBattleServiceImplementation : INavalBattleService
    {
        public static KeyValuePair<string, INavalBattleServiceCallback> player1 = new KeyValuePair<string, INavalBattleServiceCallback>();
        public static KeyValuePair<string, INavalBattleServiceCallback> player2 = new KeyValuePair<string, INavalBattleServiceCallback>();
        public static bool p1Ready;
        public static bool p2Ready;
        public static Dictionary<Point, int> shipsPlayer1 = new Dictionary<Point, int>();
        public static Dictionary<Point, int> shipsPlayer2 = new Dictionary<Point, int>();

        #region INavalBattleService Members

        public void Ready(string playerName)
        {
            if (playerName == player1.Key)
                p1Ready = true;
            else
                p2Ready = true;
            if (p1Ready && p2Ready)
                player1.Value.SetToken();
        }

        public INavalBattleServiceCallback Callback
        {
            get
            {
                return OperationContext.Current.GetCallbackChannel<INavalBattleServiceCallback>();
            }
        }

        public void Login(string playerName)
        {
            lock (this)
            {
                if (Callback != null)
                {
                    if (string.IsNullOrEmpty(player1.Key))
                    {
                        player1 = new KeyValuePair<string, INavalBattleServiceCallback>(playerName, Callback);
                        PrepareMatrix(shipsPlayer1);
                        player1.Value.NotifyLogin(player1.Key);
                    }
                    else
                    {
                        player2 = new KeyValuePair<string, INavalBattleServiceCallback>(playerName, Callback);
                        PrepareMatrix(shipsPlayer2);
                        player2.Value.NotifyLogin(playerName);
                        player2.Value.NotifyLogin(player1.Key);
                        player1.Value.NotifyLogin(playerName);
                    }
                }
            }
        }

        private void PrepareMatrix(Dictionary<Point, int> ships)
        {
            for (int x = 0; x < 15; x++)
            {
                for (int y = 0; y < 15; y++)
                {
                    ships.Add(new Point(x, y), 0);
                }
            }
        }

        public void Play(string playerName, Point coordinate)
        {
            if (Callback != null)
            {
                if (playerName == player1.Key)
                {
                    Attack(player1.Key, player2.Key, shipsPlayer2, coordinate);
                    player2.Value.SetToken();
                }
                else
                {
                    Attack(player2.Key, player1.Key, shipsPlayer1, coordinate);
                    player1.Value.SetToken();
                }
            }
        }

        private void Attack(string playerSource, string playerTarget, Dictionary<Point, int> ships, Point coordinate)
        {
            if (ships[coordinate] > 0)
            {
                int tipoNavio = ships[coordinate];
                ships[coordinate] *= -1;
                if (!ships.Values.Contains(tipoNavio))
                {
                    player1.Value.NotifyShipDestruction(playerSource, playerTarget, tipoNavio);
                    player2.Value.NotifyShipDestruction(playerSource, playerTarget, tipoNavio);
                }
                else
                {
                    player1.Value.NotifyShipHit(playerSource, playerTarget, tipoNavio);
                    player2.Value.NotifyShipHit(playerSource, playerTarget, tipoNavio);
                }
            }
            else
            {
                player1.Value.NotifyWaterShoot(playerSource, playerTarget);
                player2.Value.NotifyWaterShoot(playerSource, playerTarget);
            }
        }

        public void PutShip(string playerName, int shipType, List<Point> coordinates)
        {
            lock (this)
            {
                if (Callback != null)
                {
                    if (playerName == player1.Key)
                    {
                        PutShipInMatrix(shipsPlayer1, shipType, coordinates);
                    }
                    else
                    {
                        PutShipInMatrix(shipsPlayer2, shipType, coordinates);
                    }
                }
            }
        }

        private void PutShipInMatrix(Dictionary<Point, int> ships, int shipType, List<Point> coordinates)
        {
            lock (this)
            {
                ValidatePositions(ships, coordinates);

                if (!_erro)
                {
                    foreach (Point p in coordinates)
                        ships[p] = shipType;
                }
                else
                    _erro = false;
            }


        }
        private bool _erro = false;
        private void ValidatePositions(Dictionary<Point, int> ships, List<Point> coordinates)
        {
            foreach (Point p in coordinates)
            {
                if (ships[p] > 0)
                {
                    _erro = true;
                    throw new FaultException(new FaultReason(new FaultReasonText("Já existe outro barco nesta posição")));
                }
            }
        }

        #endregion
    }
}
