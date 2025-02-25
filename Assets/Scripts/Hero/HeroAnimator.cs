using UnityEngine;

[RequireComponent(typeof(Animator))]
public class HeroAnimator : MonoBehaviour
{
    private const string IsRunning = nameof(IsRunning);
    private const string IsStop = nameof(IsStop);

    private Animator _animator;

    private int _isRunningHash = Animator.StringToHash(nameof(IsRunning));
    private int _isStopHash = Animator.StringToHash(nameof(IsStop));

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
