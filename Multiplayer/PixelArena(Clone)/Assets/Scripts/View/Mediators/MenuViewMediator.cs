using Models;
using strange.extensions.mediation.impl;
using Signals;
using UnityEngine;

namespace View
{
    public class MenuViewMediator : TargetMediator<MenuView>
    {
        [Inject] public ChangeLevelSignal ChangeLevelSignal { get; set; }
        [Inject] public AppExitSignal AppExitSignal { get; set; }

        public override void OnRegister()
        {
            View.SingleplayerButtonClick += HandleSingleplayerButtonClick;
            View.CooperativeButtonClick += HandleCooperativeButtonClick;
            View.ExitButtonClick += HandleExitButtonClick;
        }

        public override void OnRemove()
        {
            View.SingleplayerButtonClick -= HandleSingleplayerButtonClick;
            View.CooperativeButtonClick -= HandleCooperativeButtonClick;
            View.ExitButtonClick -= HandleExitButtonClick;
        }

        private void HandleSingleplayerButtonClick()
        {
            ChangeLevelSignal.Dispatch(
                new ChangeLevelInfo
                {
                    CallerScene = gameObject.scene.name,
                    TargetScene = Constants.GameScene
                });
        }

        private void HandleCooperativeButtonClick()
        {

        }

        private void HandleExitButtonClick()
        {
            AppExitSignal.Dispatch();
        }
    }
}