using UnityEngine;
using UnityEngine.Networking;

namespace Controllers
{
    public class ServerReadyMessageHandler : IServerHandler
    {
        public short MessageType { get { return MsgType.Ready; } }
        public void Handle(NetworkMessage message)
        {
            Debug.Log("OnServerReadyMessage");
        }
    }
}