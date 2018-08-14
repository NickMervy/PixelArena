using UnityEngine;
using UnityEngine.Networking;

namespace Network.Messages
{
    public class ObjectSpawnMessage : MessageBase
    {
        public NetworkInstanceId NetId;
        public NetworkHash128 AssetId;
        public Vector3 Position;
    }
}