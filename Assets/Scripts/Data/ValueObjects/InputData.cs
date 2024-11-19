using UnityEngine;
using System;

namespace Data.ValueObjects
{
    [Serializable]
    public struct InputData
    {
        public float HorizontalInputSpeed;
        public Vector2 ClampValues;
        public float ClampSpeed;
    }
}