using System;
using Models;
using strange.extensions.signal.impl;
using View;

namespace Signals
{
    public class LocalPLayerSpawnSignal : Signal<PlayerView> { }
    public class StartServerSignal : Signal { }
    public class ConnectClientSignal : Signal<string> { }
    public class RestartServerSignal : Signal { }
    public class StopServerSignal : Signal { }
}