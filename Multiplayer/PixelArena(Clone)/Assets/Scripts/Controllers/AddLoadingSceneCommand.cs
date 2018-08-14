using System;
using Models;
using strange.extensions.command.impl;
using Services;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controllers
{
    public class AddLoadingSceneCommand : Command
    {
        [Inject] public ScenesService ScenesService { get; set; }

        public override void Execute()
        {
            var sceneName = Constants.LoadingScene;
            if (ScenesService.IsAdded(sceneName))
            {
                Debug.LogWarningFormat(@"""{0}"" scene is already unloaded", sceneName);
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

    public class CheckChangeLevelInfoCommand : Command
    {
        [Inject] public ChangeLevelInfo ChangeLevelInfo { get; set; }

        public override void Execute()
        {
            try
            {
                if (string.IsNullOrEmpty(ChangeLevelInfo.CallerScene))
                    throw new ArgumentException("", "callerScene");
                if (string.IsNullOrEmpty(ChangeLevelInfo.TargetScene))
                    throw new ArgumentException("", "targetScene");
            }

            catch (ArgumentException e)
            {
                var param = e.ParamName;
                e = new ArgumentNullException(
                    string.Format("Couldn't change level: invalid value in {0}", param));
                Debug.LogErrorFormat(e.Message);
                commandBinder.Stop(this);
                throw;
            }
        }
    }
}