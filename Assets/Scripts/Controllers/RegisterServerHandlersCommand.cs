using System.Collections.Generic;
using Services;
using strange.extensions.command.impl;
using UnityEngine.Networking;

namespace Controllers
{
    public class RegisterServerHandlersCommand : Command
    {
        [Inject] public IServer Server { get; set; }
        [Inject] public AddPlayerHandler AddPlayerHandler { get; set; }

        public override void Execute()
        {
            var handlers = new List<IServerHandler>();
            ModifyList(handlers);
            Server.RegisterHandlers(handlers);
        }

        private void ModifyList(List<IServerHandler> handlers)
        {
            handlers.Add(AddPlayerHandler);
            handlers.Add(new ServerConnectHandler());
            handlers.Add(new ServerDisconnectHandler());
            handlers.Add(new ServerErrorHandler());
            handlers.Add(new ServerReadyMessageHandler());
        }
    }
}