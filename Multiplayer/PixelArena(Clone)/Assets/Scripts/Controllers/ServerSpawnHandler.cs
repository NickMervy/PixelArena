using Network.Messages;
using Services;
using UnityEngine;
using UnityEngine.Networking;

namespace Controllers
{
    public class ServerSpawnHandler : IServerHandler
    {
        [Inject] public IServer Server { get; set; }

        public short MessageType { get { return (short)MyMsgType.Spawn; } }
        public void Handle(NetworkMessage message)
        {
            Debug.Log("OnServerSpawn");
            var spawnMessage = message.ReadMessage<ObjectSpawnMessage>();

            GameObject prefab;
            if (ClientScene.prefabs.TryGetValue(spawnMessage.AssetId, out prefab))
            {
                var networkIdentity = prefab.GetComponent<NetworkIdentity>();
                Object.Instantiate(prefab);
                networkIdentity.RebuildObservers(true);
                Server.SendToAll(MessageType, spawnMessage);
            }
        }
    }
}