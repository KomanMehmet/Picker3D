using Runtime.Enums;
using UnityEngine;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class CoreUISignals : MonoBehaviour
    {
        public static CoreUISignals Instance { get; private set; }

        public UnityAction<UIPanelTypes, int> onOpenPanel = delegate {  };
        public UnityAction<int> onClosePanel = delegate {  };
        public UnityAction onCloseAllPanel = delegate {  };
        
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(this);
        }
        
        
    }
}