using Dialogs;
using Input;
using Interactable;
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
            Interacting?.Invoke(_interactableDetector.CurrentInteractable?.Interact());
        }
    }
}
