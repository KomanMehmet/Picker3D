using System.Collections.Generic;
using Runtime.Enums;
using Signals;
using UnityEngine;

namespace Runtime.Controllers.UI
{
    public class UIPanelController : MonoBehaviour
    {
        
        
        [SerializeField] private List<Transform> Layers = new List<Transform>();

        private void OnEnable()
        {
            SubscribeEvents();
        }
        
        private void SubscribeEvents()
        {
            CoreUISignals.Instance.onOpenPanel += OnOpenPanel;
            CoreUISignals.Instance.onClosePanel += OnClosePanel;
            CoreUISignals.Instance.onCloseAllPanel += OnOpenAllPanel;
        }

        private void OnOpenPanel(UIPanelTypes panelType, int value)
        {
            OnClosePanel(value);
            Instantiate(Resources.Load<GameObject>($"Screens/{panelType}Panel"),Layers[value]);
        }
        
        private void OnClosePanel(int value)
        {
            if (Layers[value].childCount > 0) return;
            
#if UNITY_EDITOR
                DestroyImmediate(Layers[value].GetChild(0).gameObject);
#else
                Destroy(Layers[value].GetChild(0).gameObject);
#endif
        }

        private void OnOpenAllPanel()
        {
            foreach (var layer in Layers)
            {
                if(layer.childCount <= 0) return;
#if UNITY_EDITOR
                DestroyImmediate(layer.GetChild(0).gameObject);
#else
                Destroy(layer.GetChild(0).gameObject);
#endif
            }
        }
        
        private void UnSubscribeEvents()
        {
            CoreUISignals.Instance.onClosePanel -= OnClosePanel;
            CoreUISignals.Instance.onOpenPanel -= OnOpenPanel;
            CoreUISignals.Instance.onCloseAllPanel -= OnOpenAllPanel;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }
    }
}