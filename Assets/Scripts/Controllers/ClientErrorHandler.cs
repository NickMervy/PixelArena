using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

namespace Controllers
{
    public class ClientErrorHandler : IClientHandler
    {
        public short MessageType { get { return MsgType.Error; } }
        public void Handle(NetworkMessage message)
        {
            var error = message.ReadMessage<StringMessage>();
            Debug.LogErrorFormat("OnClientError");
            Debug.LogErrorFormat(error.value);
        }
    }
}