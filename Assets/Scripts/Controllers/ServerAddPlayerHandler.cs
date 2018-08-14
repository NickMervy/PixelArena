using System.Linq;
using Services;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using View;

namespace Controllers
{
    public class AddPlayerHandler : IServerHandler
    {
        [Inject] public DataService DataService { get; set; }

        public short MessageType { get { return MsgType.AddPlayer; } }
        public void Handle(NetworkMessage message)
        {
            var addPlayerMessage = message.ReadMessage<AddPlayerMessage>();
            var player = DataService.Prefabs.First(p => p.name == "Player");
            var parent = GameRoot.Instance.transform;

            player = Object.Instantiate(player, parent);

            NetworkServer.AddPlayerForConnection(message.conn, player, addPlayerMessage.playerControllerId);
            Debug.Log("Player added to the server");            
        }
    }
}