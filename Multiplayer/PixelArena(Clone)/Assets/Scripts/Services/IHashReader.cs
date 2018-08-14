using UnityEngine;

namespace Services
{
    public interface IHashReader<out T> where T : struct
    {
        T Read(GameObject obj);
    }
}