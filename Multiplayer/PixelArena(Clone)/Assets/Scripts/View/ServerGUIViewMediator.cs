using Signals;

namespace View
{
    public class ServerGUIViewMediator : TargetMediator<ServerGui>
    {
        [Inject] public StartServerSignal StartServerSignal { get; set; }
        [Inject] public ConnectClientSignal ConnectClientSignal { get; set; }

        public override void OnRegister()
        {
            View.StartHost += HandleStartHost;
            View.Connect += HandleConnection;
        }

        public override void OnRemove()
        {
            View.StartHost -= HandleStartHost;
            View.Connect -= HandleConnection;
        }

        private void HandleStartHost()
        {
            StartServerSignal.Dispatch();
            ConnectClientSignal.Dispatch("");
        }

        private void HandleConnection(string ip)
        {
            ConnectClientSignal.Dispatch("127.0.0.1");
        }
    }
}