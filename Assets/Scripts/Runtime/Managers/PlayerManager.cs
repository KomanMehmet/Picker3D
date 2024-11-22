using Runtime.Commands.Player;
using Runtime.Controllers.Player;
using Runtime.Data.UnityObjects;
using Runtime.Data.ValueObjects;
using Runtime.Keys;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Managers
{
    public class PlayerManager : MonoBehaviour
    {
        public byte StageValue;
        internal ForceBallsToPoolCommand ForceCommand;

        [SerializeField] private PlayerMovementController movementController;
        [SerializeField] private PlayerMeshController playerMeshController;
        [SerializeField] private PlayerPhysicsController physicsController;

        private PlayerData _data;

        private void Awake()
        {
            _data = GetPlayerData();
            SendDataToController();
            Init();
        }

        private PlayerData GetPlayerData()
        {
            return Resources.Load<CD_Player>("Data/CD_Player").Data;
        }

        private void SendDataToController()
        {
            movementController.SetData(_data.MovementData);
            playerMeshController.SetData(_data.MeshData);
        }

        private void Init()
        {
            ForceCommand = new ForceBallsToPoolCommand(this, _data.ForceData);
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            InputSignals.Instance.onInputTaken += () => movementController.IsReadyToMove(true);
            InputSignals.Instance.onInputReleased += () => movementController.IsReadyToMove(false);
            InputSignals.Instance.onInputDragged += OnInputDragged;
            UISignals.Instance.onPlay += () => movementController.IsReadyToPlay(true);
            CoreGameSignals.Instance.onLevelSuccessful += () => movementController.IsReadyToPlay(false);
            CoreGameSignals.Instance.onLevelFailed += () => movementController.IsReadyToPlay(false);
            CoreGameSignals.Instance.onStageAreaEntered += () => movementController.IsReadyToPlay(false);
            CoreGameSignals.Instance.onStageAreaSuccessful += OnStageAreaSuccessful;
            CoreGameSignals.Instance.onFinishAreaEntered += OnFinishAreaEntered;
            CoreGameSignals.Instance.onReset += OnReset;
        }

        private void OnInputDragged(HorizontalInputParams InputParams)
        {
            movementController.UpdateInputParams(InputParams);
        }

        private void OnStageAreaSuccessful(byte stageValue)
        {
            StageValue = (byte)++stageValue;
        }

        private void OnFinishAreaEntered()
        {
            CoreGameSignals.Instance.onLevelSuccessful?.Invoke();
            //minigame yazılmalı/ödev
        }

        private void OnReset()
        {
            StageValue = 0;
            movementController.OnReset();
            physicsController.OnReset();
            playerMeshController.OnReset();
        }

        private void UnSubscribeEvents()
        {
            InputSignals.Instance.onInputTaken -= () => movementController.IsReadyToMove(true);
            InputSignals.Instance.onInputReleased -= () => movementController.IsReadyToMove(false);
            InputSignals.Instance.onInputDragged -= OnInputDragged;
            UISignals.Instance.onPlay -= () => movementController.IsReadyToPlay(true);;
            CoreGameSignals.Instance.onLevelSuccessful -= () => movementController.IsReadyToPlay(false);
            CoreGameSignals.Instance.onLevelFailed -= () => movementController.IsReadyToPlay(false);
            CoreGameSignals.Instance.onStageAreaEntered -= () => movementController.IsReadyToPlay(false);
            CoreGameSignals.Instance.onStageAreaSuccessful -= OnStageAreaSuccessful;
            CoreGameSignals.Instance.onFinishAreaEntered -= OnFinishAreaEntered;
            CoreGameSignals.Instance.onReset -= OnReset;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }
    }   
}