using System;
using System.Collections.Generic;
using System.Linq;
using Controllers;
using Models;
using Services;
using UnityEngine;
using UnityEngine.Networking;

namespace Services
{
    public class UnityServer : IServer
    {
        public int Port { get; private set; }
        public IEnumerable<int> ActiveConnections
        {
            get
            {

                var connections = NetworkServer.connections;
                var intConnection = connections.Select(p => p.connectionId);
                return intConnection;

            }
        }

        public void Start(StartServerInfo info)
        {
            var config = info.Config;
            var port = info.Port;
            var maxConnections = info.MaxConnections;
            config.AddChannel(QosType.ReliableSequenced);
            config.AddChannel(QosType.UnreliableSequenced);
            config.PacketSize = 1470;
            NetworkServer.Configure(config, maxConnections);
            NetworkServer.Listen(port);

            if (NetworkServer.active)
            {
                Port = port;
                Debug.Log("Server started on port: " + port);
            }
            else
            {
                Debug.Log("Couldn't start server on port: " + port);
            }
        }

        public void Restart()
        {
            NetworkServer.Reset();
        }

        public void Shutdown()
        {
            NetworkServer.Shutdown();
            Debug.Log("Stop server");
        }

        public void SendToAll(short msgType, MessageBase msg)
        {
            NetworkServer.SendToAll(msgType, msg);
        }

        public void SendToClient(int connectionId, short msgType, MessageBase msg)
        {
            NetworkServer.SendToClient(connectionId, msgType, msg);
        }

        public void SendToClientOfPlayer(GameObject player, short msgType, MessageBase msg)
        {
            NetworkServer.SendToClientOfPlayer (player, msgType, msg);
        }

        public void RegisterHandlers(IEnumerable<IServerHandler> handlers)
        {
            foreach (var h in handlers)
            {
                NetworkServer.RegisterHandler(h.MessageType, h.Handle);
            }
        }
    }
}