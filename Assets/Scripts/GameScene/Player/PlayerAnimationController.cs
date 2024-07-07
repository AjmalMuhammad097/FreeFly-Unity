using UnityEngine;
using static Constants;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator playerFaceAnimator;
    [SerializeField] private Animator playerJumpAnimator;

    public void PlayJumpAnimation()
    {
        playerJumpAnimator.SetTrigger(AnimationKeys.PLAYER_JUMP_TRIGGER_ANIMATION);
    }

    public void ChangePlayerStateTo(int value)
    {
        playerFaceAnimator.SetInteger(AnimationKeys.PLAYER_MOUTH_INT_ANIMATION, value);
    }
}
