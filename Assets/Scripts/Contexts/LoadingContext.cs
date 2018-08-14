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
    public class LoadingContext : SignalContext
    {
        public LoadingContext() : base() { }
        public LoadingContext(MonoBehaviour view, bool autoStartup) : base(view, autoStartup) { }

        protected override void mapBindings()
        {
            commandBinder.Bind<StartSignal>().Once();
            commandBinder.Bind<LoadingSignal>()
                .To<HandleChangeLevelInfoCommand>()
                .To<RemoveLoadingSceneCommand>()
                .InSequence();
        }
    }
}