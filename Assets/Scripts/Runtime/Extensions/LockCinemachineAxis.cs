﻿using Unity.Cinemachine;
using UnityEngine;

namespace Runtime.Extensions
{
    [ExecuteInEditMode]
    [SaveDuringPlay]
    [AddComponentMenu("")]
    public class LockCinemachineAxis : CinemachineExtension
    {
        [Tooltip("Lock the Cinemachine Camera's X Axis position with this specific value")]
        public float XClampValue = 0;
        
        protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
        {
            if (stage == CinemachineCore.Stage.Body)
            {
                var pos = state.RawPosition;
                pos.x = XClampValue;
                state.RawPosition = pos;
            }
        }
    }
}