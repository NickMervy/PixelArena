using Contexts;
using strange.extensions.context.impl;

namespace View
{
    public class ClientRoot : ContextView
    {
        private void Awake()
        {
            context = new ClientContext(this, true);
            context.Start();
        }
    }
}