using Controllers;
using Services;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using Signals;
using UnityEngine;
using View;

namespace Contexts
{
    public class ServerContext : SignalContext
    {
        public ServerContext() : base() { }
        public ServerContext(MonoBehaviour view, bool autoStartup) : base(view, autoStartup) { }

        protected override void mapBindings()
        {
            injectionBinder.Bind<IServer>().To<UnityServer>().ToSingleton();
            injectionBinder.Bind<AddPlayerHandler>().ToSingleton();

            commandBinder.Bind<StartSignal>().Once();
            commandBinder.Bind<StartServerSignal>()
                .To<StartServerCommand>()
                .To<RegisterServerHandlersCommand>();
        }
    }
}