using System;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class PlayerInputController : MonoBehaviour
    {
        [SerializeField] private AskingWindow _askingWindow;

        private PlayerInput _input;

        public event Action<Vector3> Moving;
        public event Action Interacting;
        public event Action DialogSkiping;

        public Vector3 MovingDirection { get; private set; }

        private void Awake()
        {
            _input = new PlayerInput();
        }

        private void OnEnable()
        {
            _input.Enable();

            _input.Player.Move.performed += OnMoving;
            _input.Player.Move.canceled += OnMoving;
            _input.Player.Interact.performed += OnInteracting;
            _input.Player.DialogSkip.performed += SkipDialog;
        }

        private void OnDisable()
        {
            _input.Player.Move.performed -= OnMoving;
            _input.Player.Move.canceled -= OnMoving;
            _input.Player.Interact.performed -= OnInteracting;
            _input.Player.DialogSkip.performed -= SkipDialog;

            _input.Disable();
        }

        private void SkipDialog(InputAction.CallbackContext context)
        {
            if (_askingWindow.gameObject.activeSelf)
                return;

            DialogSkiping?.Invoke();
        }

        private void OnMoving(InputAction.CallbackContext context)
        {
            if (_askingWindow.gameObject.activeSelf)
                return;

            MovingDirection = context.action.ReadValue<Vector2>();
            MovingDirection = new Vector3(MovingDirection.x, 0f, MovingDirection.y);

            Moving?.Invoke(MovingDirection);
        }

        private void OnInteracting(InputAction.CallbackContext context)
        {
            if (_askingWindow.gameObject.activeSelf)
                return;

            Interacting?.Invoke();
        }
    }
}