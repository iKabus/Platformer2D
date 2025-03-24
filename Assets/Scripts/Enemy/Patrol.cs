using System;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;

    private bool _movingToB = true;

    public event Action HeroDetected;

    private void Update()
    {
        Patroling();
    }

    private void Patroling()
    {
        float _value = 0.1f;

        Transform target = _movingToB ? _pointB : _pointA;

        transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if ((transform.position - target.position).sqrMagnitude < _value * _value)
        {
            _movingToB = !_movingToB;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent<Hero>(out _))
        {
            HeroDetected?.Invoke();
        }
    }
}
