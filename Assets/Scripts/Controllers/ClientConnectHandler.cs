using UnityEngine;
using UnityEngine.Networking;

namespace Controllers
{
    public class ClientConnectHandler : IClientHandler
    {
        public short MessageType { get { return MsgType.Connect; } }
        public void Handle(NetworkMessage message)
        {
            Debug.Log("OnClientConnect");
            ClientScene.Ready(message.conn);
            ClientScene.AddPlayer((short)0);
        }
    }
}