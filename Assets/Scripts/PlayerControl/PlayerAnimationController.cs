using UnityEngine;

namespace PlayerControl
{
    [RequireComponent(typeof(Animator))]
    public class  PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public readonly int IsWalking = Animator.StringToHash(nameof(IsWalking));

        public void SetAnimation(bool isWalking)
        {
            _animator.SetBool(IsWalking, isWalking);
        }
    }
}
