using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Drawing;

namespace BatalhaNaval.Services
{
    // NOTE: If you change the interface name "IService1" here, you must also update the reference to "IService1" in App.config.
    
    [ServiceContract(CallbackContract = typeof(INavalBattleServiceCallback), SessionMode = SessionMode.Required)]
    public interface INavalBattleService
    {
        [OperationContract(IsOneWay = true)]
        void Login(string playerName);

        [OperationContract(IsOneWay = true)]
        void Play(string playerName, Point coordinate);

        [OperationContract(IsOneWay = true)]
        void PutShip(string playerName, int shipType, List<Point> coordinates);
        
        [OperationContract(IsOneWay = true)]
        void Ready(string playerName);

    }

 
}
