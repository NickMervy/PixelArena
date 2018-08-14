using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;

namespace Services
{
    public class JsonFileDataLoader : IDataLoader
    {
        public void Load<T>(string path, Action<T> callback)
        {
            try
            {
                if (!File.Exists(path))
                    throw new FileNotFoundException();

                using (var stream = new StreamReader(path))
                {
                    var text = stream.ReadToEnd();
                    callback(JsonUtility.FromJson<T>(text));
                }
            }

            catch (FileNotFoundException e)
            {
                e = new FileNotFoundException(
                    string.Format("Couldn't find file by path: {0}", path));
                Debug.LogErrorFormat(e.Message);
                throw;
            }
        }
    }
}