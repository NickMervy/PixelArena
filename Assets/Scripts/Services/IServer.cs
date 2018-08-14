using System;
using System.Collections.Generic;
using Controllers;
using Models;
using UnityEngine.Networking;

namespace Services
{
    public interface IServer
    {
        IEnumerable<int> ActiveConnections { get; }

        void Start(StartServerInfo info);
        void Restart();
        void Shutdown();

        void SendToAll(short msgType, MessageBase msg);
        void SendToClient(int connectionId, short msgType, MessageBase msg);
        void RegisterHandlers(IEnumerable<IServerHandler> handlers);
    }
}