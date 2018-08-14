using UnityEngine;
using UnityEngine.Networking;

namespace Controllers
{
    public class ServerDisconnectHandler : IServerHandler
    {
        public short MessageType { get { return MsgType.Disconnect; } }
        public void Handle(NetworkMessage message)
        {
            Debug.Log("OnServerDisconnect");
            NetworkServer.DestroyPlayersForConnection(message.conn);
        }
    }
}