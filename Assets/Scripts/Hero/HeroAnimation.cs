using System;
using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Animator))]

public class HeroAnimation : MonoBehaviour
{
    private Mover _mover;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _mover = GetComponent<Mover>();
    }

    private void OnEnable()
    {
        _mover.Moving += Run;
        _mover.Stoping += Stop;
        _mover.Reflecting += Reflect;
    }

    private void OnDisable()
    {
        _mover.Moving -= Run;
        _mover.Stoping -= Stop;
        _mover.Reflecting -= Reflect;
    }

    private void Run()
    {
        _animator.SetTrigger("IsRunning");
    }

    private void Stop()
    {
        _animator.SetTrigger("IsStop");
    }

    private void Reflect()
    {
        transform.localScale *= new Vector2(-1,1);
    }
}
