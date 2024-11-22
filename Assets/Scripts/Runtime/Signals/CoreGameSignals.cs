using System;
using UnityEngine;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class CoreGameSignals : MonoBehaviour
    {
        public static CoreGameSignals Instance;
        
        public UnityAction<byte> onLevelInitialize = delegate {  };
        public UnityAction onClearActiveLevel = delegate {  };
        public UnityAction onNextLevel = delegate {  };
        public UnityAction onLevelSuccessful = delegate {  };
        public UnityAction onLevelFailed = delegate {  };
        public UnityAction onRestartLevel = delegate {  };
        public UnityAction onReset = delegate {  };
        public Func<byte> onGetLevelValue = delegate { return 0; };
        public UnityAction onStageAreaEntered = delegate {  };
        public UnityAction<byte> onStageAreaSuccessful = delegate {  };
        public UnityAction onFinishAreaEntered = delegate {  };
        
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }
    }
}