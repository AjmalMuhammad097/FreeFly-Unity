using UnityEngine;
using static Constants;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _playerFaceAnimator;
    [SerializeField] private Animator _playerJumpAnimator;

    public void PlayJumpAnimation()
    {
        _playerJumpAnimator.SetTrigger(AnimationKeys.PLAYER_JUMP_TRIGGER_ANIMATION);
        Debug.Log("Playing Jump animation...");
    }

    public void ChangePlayerStateTo(int value)
    {
        if(_playerFaceAnimator.GetInteger(AnimationKeys.PLAYER_MOUTH_INT_ANIMATION) == value)
        {
            return;
        }
        Debug.Log("Changing state....");
        _playerFaceAnimator.SetInteger(AnimationKeys.PLAYER_MOUTH_INT_ANIMATION, value);
    }
}
