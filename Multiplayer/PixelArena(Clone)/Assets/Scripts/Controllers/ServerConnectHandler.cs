using UnityEngine;
using UnityEngine.Networking;

namespace Controllers
{
    public class ServerConnectHandler : IServerHandler
    {
        public short MessageType { get { return MsgType.Connect; } }
        public void Handle(NetworkMessage message)
        {
            Debug.Log("OnServerConnect");
        }
    }
}