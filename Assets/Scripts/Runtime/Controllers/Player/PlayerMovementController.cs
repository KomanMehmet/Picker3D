using System;
using Runtime.Data.ValueObjects;
using Runtime.Keys;
using Unity.Mathematics;
using UnityEngine;

namespace Runtime.Controllers.Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private Rigidbody playerRb;

        private PlayerMovementData _data;
        private bool _isReadyToMove;
        private bool _isReadyToPlay;
        private float _xValue;
        private float2 _clampValues;

        public void SetData(PlayerMovementData data)
        {
            _data = data;
        }

        private void FixedUpdate()
        {
            if (!_isReadyToPlay)
            {
                StopPlayer();
                return;
            }

            if (_isReadyToMove)
            {
                MovePlayer();
            }
            else
            {
                StopPlayerHorizontally();
            }
        }
        

        private void StopPlayer()
        {
            playerRb.linearVelocity = Vector3.zero;
            playerRb.angularVelocity = Vector3.zero;
        }
        
        private void StopPlayerHorizontally()
        {
            playerRb.linearVelocity = new Vector3(0f, playerRb.linearVelocity.y, _data.ForwardSpeed);
            playerRb.angularVelocity = Vector3.zero;
        }

        private void MovePlayer()
        {
            var velocity = playerRb.linearVelocity;
            velocity = new Vector3(_xValue * _data.SidewaySpeed, velocity.y, _data.ForwardSpeed);
            playerRb.linearVelocity = velocity;

            var position1 = playerRb.position;
            Vector3 position;
            position = new Vector3(Mathf.Clamp(position1.x, _clampValues.x, _clampValues.y),
                (position = playerRb.position).y, position.z);
            playerRb.position = position;
        }

        internal void IsReadyToPlay(bool condition)
        {
            _isReadyToPlay = condition;
        }

        internal void IsReadyToMove(bool condition)
        {
            _isReadyToMove = condition;
        }

        internal void UpdateInputParams(HorizontalInputParams inputParams)
        {
            _xValue = inputParams.HorizontalValue;
            _clampValues = inputParams.ClampValues;
        }

        internal void OnReset()
        {
            StopPlayer();
            _isReadyToMove = false;
            _isReadyToPlay = false;
        }
    }
}