using System.Collections.Generic;
using System.Linq;
using strange.extensions.command.impl;
using Services;
using UnityEngine.Networking;
using View;

namespace Controllers
{
    public class RegisterNetworkPrefabsCommand : Command
    {
        [Inject] public DataService DataService { get; set; }

        public override void Execute()
        {
            var networkPrefabs = DataService.Prefabs.Where(p => 
                p.GetComponent<NetworkIdentity>());
            foreach (var p in networkPrefabs)
            {
                ClientScene.RegisterPrefab(p);
            }
        }
    }
}