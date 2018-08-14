using strange.extensions.command.impl;
using Services;
using UnityEngine;

namespace Controllers
{
    public class AddServerSceneCommand : Command
    {
        [Inject]
        public ScenesService ScenesService { get; set; }

        public override void Execute()
        {
            var sceneName = Constants.ServerScene;
            if (ScenesService.IsAdded(sceneName))
            {
                Debug.LogWarningFormat(@"""{0}"" scene is already loaded", sceneName);
                return;
            }

            Retain();
            var operation = ScenesService.LoadAsync(sceneName);
            operation.OnComplete(Callback);
        }

        public void Callback()
        {
            Debug.Log("Released");
            Release();
        }
    }
}