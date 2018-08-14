using Models;
using Services;
using strange.extensions.command.impl;
using UnityEditor.Experimental.UIElements.GraphView;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

namespace Controllers
{
    public class StartServerCommand : Command
    {
        [Inject] public IServer Server { get; set; }

        public override void Execute()
        {
            var info = new StartServerInfo()
            {
                Port = Constants.ServerPort,
                MaxConnections = Constants.MultiplayerMaxConnections,
                Config = new ConnectionConfig()
            };

            Server.Start(info);
        }
    }
}