using System.Runtime.CompilerServices;
using Contexts;
using strange.extensions.context.impl;

namespace View
{ 
    public class GameRoot : ContextView
    {
        public static GameRoot Instance;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else if(Instance == this)
                Destroy(gameObject);

            context = new GameContext(this, true);
            context.Start();
        }
    }
}
