using Runtime.Enums;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class CoreUISignals : MonoBehaviour
    {
        public static CoreUISignals Instance;
        

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }
        
        public UnityAction<UIPanelTypes, int> onOpenPanel = delegate {  };
        public UnityAction<int> onClosePanel = delegate {  };
        public UnityAction onCloseAllPanel = delegate {  };
    }
}