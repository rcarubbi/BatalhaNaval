using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Drawing;

namespace BatalhaNaval.Services
{

    [ServiceContract]
    public interface INavalBattleServiceCallback
    {
        [OperationContract]
        void NotifyLogin(string playerName);
        [OperationContract]
        void NotifyPlay(string playerName, Point coordinate);
        [OperationContract]
        void NotifyPutShip(string playerName, int shipType, List<Point> coordinates);
        [OperationContract]
        void NotifyShipDestruction(string playerSource, string playerTarget, int tipoNavio);
        [OperationContract]
        void NotifyWaterShoot(string playerSource, string playerTarget);
        [OperationContract]
        void NotifyShipHit(string playerSource, string playerTarget, int tipoNavio);
        [OperationContract]
        void SetToken();

        [OperationContract]
        void NotifyIlegalCall(string message);
    }


}
