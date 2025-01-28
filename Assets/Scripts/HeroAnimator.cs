using System;
using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Animator))]
public class HeroAnimator : MonoBehaviour
{
    private Mover _mover;
    private Animator _animator;
    
    private int _isRunningHash = Animator.StringToHash("IsRunning");
    private int _isStopHash = Animator.StringToHash("IsStop");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _mover = GetComponent<Mover>();
    }

    private void OnEnable()
    {
        _mover.Moving += Run;
        _mover.Stoping += Stop;
    }

    private void OnDisable()
    {
        _mover.Moving -= Run;
        _mover.Stoping -= Stop;
    }

    private void Run()
    {
        _animator.SetTrigger(_isRunningHash);
    }

    private void Stop()
    {
        _animator.SetTrigger(_isStopHash);
    }
}
