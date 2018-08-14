using System;
using System.Collections.Generic;
using Controllers;
using UnityEngine;
using UnityEngine.Networking;

namespace Services
{
    public class UnityClientConnector : IConnector
    {
        private NetworkClient _client;

        public void Connect(string ip, int port)
        {
            var config = new ConnectionConfig();
            config.AddChannel(QosType.ReliableSequenced);
            config.AddChannel(QosType.UnreliableSequenced);
            config.PacketSize = 1470;
            var maxConnections = Constants.MultiplayerMaxConnections;

            _client = new NetworkClient();
            _client.Configure(config, maxConnections);

            _client.Connect(ip, port);
        }

        public void ConnectLocalHost()
        {
            if (!NetworkServer.active)
            {
                Debug.LogError("Start server first");
                return;
            }

            _client = ClientScene.ConnectLocalServer();
        }

        public void Disconect()
        {
            if (_client != null)
            {
                _client.Disconnect();
            }
            else
            {
                Debug.LogError("You should connect to server first");
            }
        }

        public void Send(short msgId, MessageBase msg)
        {
            if (_client != null)
            {
                _client.Send(msgId, msg);
            }
            else
            {
                Debug.LogError("You should connect to server first");
            }
        }

        public void RegisterMessageHandlers(IEnumerable<IClientHandler> handlers)
        {
            foreach (var h in handlers)
            {
                _client.RegisterHandler(h.MessageType, h.Handle);
            }
        }
    }
}