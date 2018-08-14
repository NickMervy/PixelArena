using Services;
using UnityEngine;
using UnityEngine.Networking;

namespace Controllers
{
    public class ServerErrorHandler : IServerHandler
    {
        public short MessageType { get { return MsgType.Error; } }
        public void Handle(NetworkMessage message)
        {
            Debug.Log("OnServerError");
        }
    }
}