using Signals;
using UnityEngine.Networking;

namespace Controllers
{
    public interface IClientHandler
    {
        short MessageType { get; }
        void Handle(NetworkMessage message);
    }
}