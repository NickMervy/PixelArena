using strange.extensions.command.impl;
using Services;
using UnityEngine.Networking;

namespace Controllers
{
    public class ConnectCommand : Command
    {
        [Inject] public IConnector Connector { get; set; }
        [Inject] public string Ip { get; set; }
        
        //todo
        public override void Execute()
        {
            if (string.IsNullOrEmpty(Ip))
            {
                Connector.ConnectLocalHost();
            }
            else
            {
                Connector.Connect(Ip, Constants.ServerPort);
            }
        }
    }
}