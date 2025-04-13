using Input;
using System;
using UnityEngine;

namespace PlayerControl
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private PlayerInputController _input;
        [SerializeField] private PlayerAnimationController _animationController;
        [SerializeField] private float _speed = 3f;

        public event Action Moved;

        private void OnDisable()
        {
            _animationController.SetAnimation(false);
        }

        private void FixedUpdate()
        {
            transform.position += _speed * Time.fixedDeltaTime * _input.MovingDirection;

            if (_input.MovingDirection != Vector3.zero)
            {
                transform.forward = _input.MovingDirection;
                Moved?.Invoke();
            }

            _animationController.SetAnimation(_input.MovingDirection != Vector3.zero);
        }
    }
}
