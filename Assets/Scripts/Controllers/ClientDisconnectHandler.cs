using UnityEngine;
using UnityEngine.Networking;

namespace Controllers
{
    public class ClientDisconnectHandler : IClientHandler
    {
        public short MessageType { get { return MsgType.Disconnect; } }
        public void Handle(NetworkMessage message)
        {
            Debug.Log("OnClientDisconnect");
        }
    }
}