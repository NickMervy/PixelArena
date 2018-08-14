using Signals;
using UnityEditor;

namespace View
{
    public class RoomViewMediator : TargetMediator<RoomView>
    {
        [Inject] public AttachRoomEdgesSignal AttachRoomEdgesSignal { get; set; }

        public override void OnRegister()
        {
            View.OnStart += HandleOnStart;
        }

        public override void OnRemove()
        {
            View.OnStart -= HandleOnStart;
        }

        private void HandleOnStart()
        {
            AttachRoomEdgesSignal.Dispatch(View.Edges);
        }
    }
}