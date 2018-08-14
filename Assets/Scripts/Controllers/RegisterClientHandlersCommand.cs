using System.Collections.Generic;
using Services;
using strange.extensions.command.impl;
using Services;
using UnityEngine;

namespace Controllers
{
    public class RegisterClientMessageHandlersCommand : Command
    {
        [Inject]
        public IConnector Connector { get; set; }

        public override void Execute()
        {
            var handlers = new List<IClientHandler>();
            ModifyList(handlers);
            Connector.RegisterMessageHandlers(handlers);
        }

        private void ModifyList(ICollection<IClientHandler> handlers)
        {
            handlers.Add(new ClientConnectHandler());
            handlers.Add(new ClientDisconnectHandler());
            handlers.Add(new ClientErrorHandler());
            handlers.Add(new ClientNotReadyMessageHandler());
            handlers.Add(new ClientSceneHandler());
        }
    }
}