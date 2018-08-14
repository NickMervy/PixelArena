using System;
using UnityEngine;
using UnityEngine.Networking;

namespace Services
{
    public class NetworkHash128Reader : IHashReader<NetworkHash128>
    {
        public NetworkHash128 Read(GameObject prefab)
        {
            try
            {
                var identity = prefab.GetComponent<NetworkIdentity>();
                if (identity == null)
                    throw new NullReferenceException();

                return identity.assetId;
            }

            catch (NullReferenceException e)
            {
                e = new NullReferenceException(string.Format(
                    @"Couldn't find ""NetworkIdentity"" component on {0}", prefab.name));
                Debug.LogErrorFormat(e.Message);
                throw;
            }
        }
    }
}