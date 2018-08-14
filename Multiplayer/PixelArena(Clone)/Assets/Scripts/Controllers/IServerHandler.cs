using System;
using Services;
using UnityEngine.Networking;

namespace Controllers
{
    public interface IServerHandler
    {
        short MessageType { get; }
        void Handle(NetworkMessage message);
    }
}