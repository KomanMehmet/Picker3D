using Runtime.Signals;
using Unity.Cinemachine;
using Unity.Mathematics;
using UnityEngine;

namespace Runtime.Managers
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private CinemachineCamera cinemachineCamera;

        private float3 _firstPosition;

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            _firstPosition = transform.position;
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CameraSignals.Instance.onSetCameraTarget += OnSetCameraTarget;
            CoreGameSignals.Instance.onReset += OnReset;
        }

        private void OnSetCameraTarget()
        {
            var player = FindObjectOfType<PlayerManager>().transform;
            cinemachineCamera.Follow = player;
            //cinemachineCamera.LookAt = player;
        }

        private void OnReset()
        {
            transform.position = _firstPosition;
        }
        
        private void UnSubscribeEvents()
        {
            CameraSignals.Instance.onSetCameraTarget -= OnSetCameraTarget;
            CoreGameSignals.Instance.onReset -= OnReset;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }
    }
}