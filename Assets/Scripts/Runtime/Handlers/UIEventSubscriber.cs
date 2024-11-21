using System;
using Runtime.Enums;
using Runtime.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Handlers
{
    public class UIEventSubscriber : MonoBehaviour
    {
        [SerializeField] private UIEventSubscribtionTypes type;
        [SerializeField] private Button button;

        private UIManager _uiManager;

        private void Awake()
        {
            GetReferences();
        }

        private void GetReferences()
        {
            _uiManager = FindObjectOfType<UIManager>();
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            switch (type)
            {
                case UIEventSubscribtionTypes.OnPlay:
                    button.onClick.AddListener(_uiManager.Play);
                    break;
                case UIEventSubscribtionTypes.OnNextLevel:
                    button.onClick.AddListener(_uiManager.NexLevel);
                    break;
                case UIEventSubscribtionTypes.OnRestartLevel:
                    button.onClick.AddListener(_uiManager.RestartLevel);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            /*button.onClick += type switch
            {
                UIEventSubscribtionTypes.OnPlay => _uıManager.Play,
                UIEventSubscribtionTypes.OnNextLevel => _uıManager.NexLevel,
                UIEventSubscribtionTypes.OnRestartLevel => _uıManager.RestartLevel,
                _ => throw new ArgumentOutOfRangeException()
            };*/
        }
        
        private void UnSubscribeEvents()
        {
            switch (type)
            {
                case UIEventSubscribtionTypes.OnPlay:
                    button.onClick.RemoveListener(_uiManager.Play);
                    break;
                case UIEventSubscribtionTypes.OnNextLevel:
                    button.onClick.RemoveListener(_uiManager.NexLevel);
                    break;
                case UIEventSubscribtionTypes.OnRestartLevel:
                    button.onClick.RemoveListener(_uiManager.RestartLevel);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }
    }
}