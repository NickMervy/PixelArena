using Controllers;
using UnityEngine;
using UnityEngine.Networking;

namespace Services
{
    public class RemovePlayerHandler : IServerHandler
    {
        public short MessageType { get { return MsgType.RemovePlayer; } }

        public void Handle(NetworkMessage message)
        {
            Debug.Log("Player removed from the server");
        }
    }
}