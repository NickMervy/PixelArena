using System;
using strange.extensions.mediation.impl;
using Services;
using UnityEngine;
using UnityEngine.Networking;

namespace View
{
    public class ServerGui : EventView
    {
        public event Action StartHost;
        public event Action<string> Connect;
        public event Action RestartServer;
        public event Action StopHost;
    
        private void OnGUI()
        {
            GUILayout.Space(300);

            var probablyServerIp = 0;
            var input = GUILayout.TextField("Server ip is here");
            

            if (!NetworkServer.active)
            {
                if (GUILayout.Button("Start host"))
                {
                    StartHost();
                }
                if (GUILayout.Button("Connect"))
                {
                    Connect(input);
                }
            }
            else
            {
                if (GUILayout.Button("Restart"))
                {
                    RestartServer();
                }

                if (GUILayout.Button("Stop"))
                {
                    StopHost();;
                }
            }

            if (!NetworkServer.active)
                return;


            GUILayout.Space(20);

            GUILayout.Label("Server status:");

            GUILayout.Label("Server Errors");
        }
    }
}