using System;
using Runtime.Managers;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Controllers.Player
{
    public class PlayerPhysicsController : MonoBehaviour
    {
        [SerializeField] private PlayerManager manager;
        [SerializeField] private Collider collider;
        [SerializeField] private Rigidbody playerRb;

        private readonly string _stageAreaTag = "StageArea";
        private readonly string _finishAreaTag = "FinishArea";
        private readonly string _miniGame = "MiniGameArea";

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(_stageAreaTag))
            {
                manager.ForceCommand.Execute();
                CoreGameSignals.Instance.onStageAreaEntered?.Invoke();
                InputSignals.Instance.onDisableInput?.Invoke();
                
                //Stage Area Kontrol Süreci
            }

            if (other.gameObject.CompareTag(_finishAreaTag))
            {
                CoreGameSignals.Instance.onFinishAreaEntered?.Invoke();
                InputSignals.Instance.onDisableInput?.Invoke();
                CoreGameSignals.Instance.onLevelSuccessful?.Invoke();
                return;
            }

            if (other.gameObject.CompareTag(_miniGame))
            {
                //Write the Minigame Mechanics
            }
        }

        internal void OnReset()
        {
            
        }
    }
}