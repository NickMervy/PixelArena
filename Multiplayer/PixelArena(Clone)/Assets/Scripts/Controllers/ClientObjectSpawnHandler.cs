using Controllers;
using Network.Messages;
using UnityEngine;
using UnityEngine.Networking;

namespace Controllers
{
    public class ClientObjectSpawnHandler : IClientHandler
    {
        public short MessageType { get { return (short)MyMsgType.Spawn; } }
        public void Handle(NetworkMessage message)
        {
            Debug.Log("OnClientSpawn");
            var spawnMessage = message.ReadMessage<ObjectSpawnMessage>();

            GameObject prefab;
            if (ClientScene.prefabs.TryGetValue(spawnMessage.AssetId, out prefab))
            {
                Object.Instantiate(prefab);
            }
        }
    }
}