using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BatalhaNaval.Client.NavalBattleProxy;
using System.ServiceModel;

namespace BatalhaNaval.Client
{
    public partial class frmGame : Form, INavalBattleServiceCallback
    {
        public frmGame()
        {
            InitializeComponent();
            _instanceContext = new InstanceContext(this);
            _attackDialog = new PutShipDialog();
            _attackDialog.OnSelectedCell += new EventHandler<CellSelectedEventArgs>(_attackDialog_OnSelectedCell);
        }

        void _attackDialog_OnSelectedCell(object sender, CellSelectedEventArgs e)
        {
            Proxy.Play(_playerName, e.Coordinates);
        }

        private void frmGame_Load(object sender, EventArgs e)
        {
            navalBattlePanelPlayer1.ReadOnly = true;
            navalBattlePanelPlayer2.ReadOnly = true;
        }

        protected NavalBattleServiceClient _proxy;
        private InstanceContext _instanceContext;
        private string _playerName;
        private string _oponentName;
        private PutShipDialog _attackDialog;
        private int _shipId;
        public NavalBattleServiceClient Proxy
        {
            get
            {
                if (_proxy == null)
                {
                    _proxy = new NavalBattleServiceClient(_instanceContext);
                    _proxy.Open();
                }

                if (_proxy.State != CommunicationState.Opened && _proxy.State != CommunicationState.Opening)
                {
                    if (_proxy.State != CommunicationState.Closed && _proxy.State != CommunicationState.Closing && _proxy.State != CommunicationState.Faulted)
                    {
                        _proxy.Close();
                    }
                    _proxy = null;
                    _proxy = new NavalBattleServiceClient(_instanceContext);
                    _proxy.Open();
                }
                return _proxy;
            }
            set
            {
                _proxy = value;
            }
        }



        private void btnLogin_Click(object sender, EventArgs e)
        {
            _playerName = txtPlayerName.Text;
            Proxy.Login(_playerName);

        }

        #region INavalBattleServiceCallback Members

        public void NotifyLogin(string playerName)
        {
            if (playerName == _playerName)
                lblPlayer1.Text = playerName;
            else
            {
                lblPlayer2.Text = playerName;
                _oponentName = playerName;
            }

            if (IsReadyToPutShips)
            {
                StartPutShips();
            }
        }

        private bool IsReadyToPutShips
        {
            get
            {
                return !string.IsNullOrEmpty(_playerName) && !string.IsNullOrEmpty(_oponentName);
            }
        }

        private void StartPutShips()
        {
            navalBattlePanelPlayer1.ReadOnly = false;
            gpbOrientacao.Visible = true;
            _shipId = 1;
        }




        public void NotifyIlegalCall(string message)
        {
            MessageBox.Show(message);
     
        }

        public void NotifyPlay(string playerName, Point coordinate)
        {
            MessageBox.Show(string.Format("{0} atacou {1}-{2}", playerName, coordinate.X, coordinate.Y));
        }

        public void NotifyPutShip(string playerName, int shipType, Point[] coordinates)
        {
            if (playerName == _playerName)
            {
                foreach (Point p in coordinates)
                {
                    ((TextBox)this.navalBattlePanelPlayer1.GetChildAtPoint(p)).Text = shipType.ToString();
                }
            }
        }

        public void NotifyShipDestruction(string playerSource, string playerTarget, int tipoNavio)
        {
            MessageBox.Show(string.Format("{0} destruiu o navio {1} de {2}", playerSource, tipoNavio,   playerTarget));
        }

        public void NotifyWaterShoot(string playerSource, string playerTarget)
        {
            MessageBox.Show(string.Format("{0} disparou contra {1} e acertou a agua", playerSource, playerTarget));
        }

        public void NotifyShipHit(string playerSource, string playerTarget, int tipoNavio)
        {
            MessageBox.Show(string.Format("{0} acertou uma parte do navio {1} de {2}", playerSource, tipoNavio, playerTarget));
        }

        public void SetToken()
        {
            _attackDialog.Show();
        }


        private bool _invalidCall = false;
        #endregion

        private void navalBattlePanelPlayer1_OnSelectedCell(object sender, CellSelectedEventArgs e)
        {
            int x = e.Coordinates.X;
            int y = e.Coordinates.Y;
            Orientation? orientacao = null;
            
            try
            {
                orientacao = GetOrientation();
            }
            catch(ApplicationException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }


            List<Point> coordinates = new List<Point>();
            for (int i = 0; i < _shipId; i++)
            {
                Point nextPosition;
                if (orientacao.Value == Orientation.Horizontal)
                    nextPosition = new Point(x, y++);
                else
                    nextPosition = new Point(x++, y);

                coordinates.Add(nextPosition);
            }

            try
            {
                Proxy.PutShip(_playerName, _shipId, coordinates.ToArray());
            }
            catch(Exception ex)
            {
                 MessageBox.Show(ex.Message);
                 return;
            }


           
                this.navalBattlePanelPlayer1.PutShip(_shipId, e.Coordinates, orientacao.Value, _shipId);

                if (_shipId < 7)
                    _shipId++;
                else
                    FinishPutShips();
           
                
        }

        private void FinishPutShips()
        {
            gpbOrientacao.Visible = false;
            navalBattlePanelPlayer1.ReadOnly = true;
            Proxy.Ready(_playerName);
        }

        private Orientation GetOrientation()
        {
            if (rdbHorizontal.Checked)
                return Orientation.Horizontal;
            else if (rdbVertical.Checked)
                return Orientation.Vertical;
            else
                throw new ApplicationException("Selecione uma orientação");
        }
    }
}
