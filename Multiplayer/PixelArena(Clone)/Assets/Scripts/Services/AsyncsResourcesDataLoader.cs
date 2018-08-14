using System;
using System.IO;
using UniRx;
using UnityEngine;

namespace Services
{
    public class AsyncsResourcesDataLoader : IDataLoader
    {
        public void Load<T>(string path, Action<T> callback)
        {
            try
            {
                var request = Resources.LoadAsync(path);
                if (request == null)
                    throw new FileNotFoundException();

                request.AsObservable()
                    .DoOnError(ex =>{ throw ex; })
                    .DoOnCompleted(() =>
                    {
                        callback((T) Convert.ChangeType(request.asset, typeof (T)));
                    }).Subscribe();
            }

            catch (InvalidCastException e)
            {
                Debug.LogException(e);
                throw;
            }

            catch (FileNotFoundException e)
            {
                e = new FileNotFoundException(
                    string.Format("Couldn't find asset by path: {0}/{1}",
                        Application.dataPath, path));
                Debug.LogErrorFormat(e.Message);
                throw;
            }
        }
    }
}