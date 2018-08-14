using Controllers;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using Services;
using Signals;
using UnityEngine;

namespace Contexts
{
    public class ClientContext : SignalContext
    {
        public ClientContext() : base() { }
        public ClientContext(MonoBehaviour view, bool autoStartup) : base(view, autoStartup) { }

        protected override void mapBindings()
        {
            injectionBinder.Bind<IConnector>().To<UnityClientConnector>().ToSingleton().CrossContext();

            commandBinder.Bind<StartSignal>().Once();
            commandBinder.Bind<ConnectClientSignal>()
                .To<ConnectCommand>()
                .To<RegisterClientMessageHandlersCommand>()
                .To<RegisterNetworkPrefabsCommand>();
        }

        public override void OnRemove()
        {
            base.OnRemove();
            injectionBinder.Unbind<IConnector>();
        }
    }
}