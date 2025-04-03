using UnityEngine;

[RequireComponent(typeof(Animator))]
public class HeroAnimator : MonoBehaviour
{
    private const string IsRunning = "IsRunning";
    private const string IsStop = "IsStop";

    private Animator _animator;

    private readonly int _isRunningHash = Animator.StringToHash(IsRunning);
    private readonly int _isStopHash = Animator.StringToHash(IsStop);

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayMove()
    {
        _animator.SetTrigger(_isRunningHash);
    }

    public void PlayIdle()
    {
        _animator.SetTrigger(_isStopHash);
    }
}
