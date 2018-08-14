using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Services
{
    public interface IDataLoader
    {
        void Load<T>(string path, Action<T> callback);
    }
}
