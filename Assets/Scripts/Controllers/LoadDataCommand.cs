using strange.extensions.command.impl;
using Services;
using UnityEngine;

namespace Controllers
{
    public class LoadDataCommand : Command
    {
        [Inject] public DataService DataService { get; set; }

        public override void Execute()
        {
            Retain();
            DataService.LoadPrefabs(OnComplete);
        }

        private void OnComplete()
        {
            Retain();
            Debug.Log("LoadDataCommand released");
        }
    }
}