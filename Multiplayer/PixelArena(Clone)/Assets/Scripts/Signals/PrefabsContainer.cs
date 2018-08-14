using System.Collections.Generic;
using UnityEngine;

namespace Models
{
    [CreateAssetMenu(fileName = "PrefabsContainer", menuName = "Containers/Prefabs Container")]
    public class PrefabsContainer : ScriptableObject
    {
        [SerializeField] private List<GameObject> _prefabs;

        public List<GameObject> Prefabs { get {return _prefabs; } }
    }
}