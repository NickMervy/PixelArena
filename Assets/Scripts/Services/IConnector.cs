using System;
using System.Collections.Generic;
using Controllers;
using UnityEngine.Networking;

namespace Services
{
    public interface IConnector
    {
        void Connect(string ip, int port);
        void ConnectLocalHost();
        void Disconect();

        void Send(short msgId, MessageBase msg);
        void RegisterMessageHandlers(IEnumerable<IClientHandler> handlers);
    }
}