using Dialogs;
using Input;
using InteractableObjects;
using System;
using UnityEngine;

namespace PlayerControl
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private InteractableDetector _interactableDetector;
        [SerializeField] private PlayerInputController _input;
        [SerializeField] private Movement _movement;

        public event Action<Dialog> Interacting;

        public Movement Movement => _movement;

        private void OnEnable()
        {
            _input.Interacting += Interacted;
            _movement.enabled = true;
        }

        private void OnDisable()
        {
            _input.Interacting -= Interacted;
            _movement.enabled = false;
        }

        private void Interacted()
        {
            if (_interactableDetector.CurrentInteractable != null)
                Interacting?.Invoke(_interactableDetector.CurrentInteractable.Interact());
        }
    }
}
