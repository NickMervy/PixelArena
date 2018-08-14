using Signals;

namespace Services
{
    public class LoadingFacade
    {
        private LoadingSignal Signal;

        public LoadingFacade(LoadingSignal Signal)
        {
            this.Signal = Signal;
        }
    }
}