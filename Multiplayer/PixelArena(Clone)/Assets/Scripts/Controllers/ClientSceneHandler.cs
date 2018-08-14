using UnityEngine;
using UnityEngine.Networking;

namespace Controllers
{
    public class ClientSceneHandler : IClientHandler
    {
        public short MessageType { get { return MsgType.Scene; } }
        public void Handle(NetworkMessage message)
        {
            Debug.Log("OnClientScene");
        }
    }
}