using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Constants
{
    public const int ServerPort = 95555;
    public const int MultiplayerMaxConnections = 2;

    public const string MainScene = "Main";
    public const string MenuScene = "Menu";
    public const string GameScene = "Game";
    public const string ClientScene = "Client";
    public const string ServerScene = "Server";
    public const string CamerasScene = "Cameras";
    public const string LoadingScene = "Loading";

    public const string PrefabsContainerPath = "PrefabsContainer";
}

public enum MyMsgType : short
{
    Spawn = MsgType.Highest + 1,
    UnSpawn,
    Destroy
}
