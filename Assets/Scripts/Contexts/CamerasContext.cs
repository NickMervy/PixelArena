using Controllers;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using Signals;
using UnityEngine;
using View;

namespace Contexts
{
    public class CamerasContext : MVCSContext
    {
        public CamerasContext() : base() { }
        public CamerasContext(MonoBehaviour view, bool autoStartup) : base(view, autoStartup) { }

        protected override void mapBindings()
        {
            commandBinder.Bind<StartSignal>().Once();
            mediationBinder.Bind<VirtualCamera2DView>()
                .To<VirtualCamera2DViewMediator>();
        }
    }
}