using Cinemachine;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace View
{
    public class VirtualCamera2DView : EventView
    {
        public CinemachineConfiner Confiner;
        public CinemachineVirtualCamera VirtCamera;

        public void SetBounders(Collider2D collder2D)
        {
            Confiner.m_BoundingShape2D = collder2D;
        }

        public void SetFollowTarget(GameObject obj)
        {
            VirtCamera.Follow = obj.transform;
        }
    }
}