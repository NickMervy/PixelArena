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
    public class SignalContext : MVCSContext
    {
        public SignalContext() : base() { }
        public SignalContext(MonoBehaviour view, bool autoStartup) : base(view, autoStartup) { }

        protected override void addCoreComponents()
        {
            base.addCoreComponents();
            injectionBinder.Unbind<ICommandBinder>();
            injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
        }

        public override IContext Start()
        {
            base.Start();
            var startSignal = injectionBinder.GetInstance<StartSignal>();
            startSignal.Dispatch();
            return this;
        }
    }

    public class MainContext : SignalContext
    {
        public MainContext() : base() { }
        public MainContext(MonoBehaviour view, bool autoStartup) : base(view, autoStartup) { }

        protected override void mapBindings()
        {
            injectionBinder.Bind<IDataLoader>().To<AsyncsResourcesDataLoader>().CrossContext();
            injectionBinder.Bind<AttachRoomEdgesSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<ScenesService>().ToSingleton().CrossContext();
            injectionBinder.Bind<DataService>().ToSingleton().CrossContext();

            injectionBinder.Bind<ChangeLevelSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<ConnectClientSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<LocalPLayerSpawnSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<LoadingSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<StartServerSignal>().ToSingleton().CrossContext();

            commandBinder.Bind<StartSignal>()
                .To<AddCamerasSceneCommand>() 
                .To<AddClientSceneCommand>()
                .To<AddServerSceneCommand>()
                .To<LoadDataCommand>()
                .To<RegisterNetworkPrefabsCommand>()
                .InSequence();

            commandBinder.Bind<ChangeLevelSignal>()
                .To<CheckChangeLevelInfoCommand>()
                .To<AddLoadingSceneCommand>()
                .To<RemoveCallerSceneCommand>()
                .To<AddTargetSceneCommand>()
                .InSequence();
        }
    }
}