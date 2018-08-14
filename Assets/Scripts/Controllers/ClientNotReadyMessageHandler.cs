using Services;
using UnityEngine;
using UnityEngine.Networking;

namespace Controllers
{
    public class ClientNotReadyMessageHandler : IClientHandler
    {
        public short MessageType { get { return MsgType.NotReady; } }
        public void Handle(NetworkMessage message)
        {
            Debug.Log("OnClientNotReadyMessage");
        }
    }
}