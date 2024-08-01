using System;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class CoreGameSignals : MonoBehaviour
    {
        public static CoreGameSignals Instance;

        public UnityAction<byte> onLevelInitialize = delegate {  };
        public UnityAction onClearActiveLevel = delegate {  };
        public UnityAction onNextLEvel = delegate {  };
        public UnityAction OnRestartLevel = delegate {  };
        public UnityAction onReset = delegate {  };
        public Func<byte> onGetLevelValue = delegate { return 0; };
        
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