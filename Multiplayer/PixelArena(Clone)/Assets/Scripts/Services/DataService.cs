using System;
using System.Collections.Generic;
using Models;
using UnityEngine;
using UnityEngine.Networking;

namespace Services
{
    public class DataService
    {
        private readonly IDataLoader _loader;

        public DataService(IDataLoader loader)
        {
            _loader = loader;
        }

        public IEnumerable<GameObject> Prefabs { get; private set; }
        public Dictionary<NetworkHash128, GameObject> NetworkPrefabs { get; private set; }

        public void LoadPrefabs()
        {
            _loader.Load<PrefabsContainer>(Constants.PrefabsContainerPath, pc =>
            {
                Prefabs = pc.Prefabs;
                Debug.Log("Prefabs loaded");
            });
        }

        public void LoadPrefabs(Action callback)
        {
            _loader.Load<PrefabsContainer>(Constants.PrefabsContainerPath, pc =>
            {
                Prefabs = pc.Prefabs;
                Debug.Log("Prefabs loaded");
                callback();
            });
        }

        public void SetNerworkDictionary()
        {
            foreach (var p in Prefabs)
            {
                var networkIdentity = p.GetComponent<NetworkIdentity>();
                if (networkIdentity != null)
                {
                    var key = networkIdentity.assetId;
                    NetworkPrefabs.Add(key, p);
                }
            }
        }
    }
}