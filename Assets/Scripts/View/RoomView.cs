using System;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace View
{
    public class RoomView : EventView
    {
        public event Action OnStart;

        public Grid Grid;
        public Collider2D Edges;

        protected override void Start()
        {
            OnOnStart();
        }

        protected virtual void OnOnStart()
        {
            var handler = OnStart;
            if (handler != null) handler();
        }
    }
}