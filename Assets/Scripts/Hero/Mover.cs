using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField, Min(0.1f)] private float _speed;

    public bool IsMove {  get; private set; } = false;

    private Rigidbody2D _rigidBody2D;

    private float _minSpeed = 0.1f;

    private bool _isRight = true;

    public event Action Reflecting;

    private void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    public void Move(float direction)
    {
        _rigidBody2D.linearVelocity = new Vector2(direction * _speed, _rigidBody2D.linearVelocity.y);

        IsMove = Mathf.Abs(direction) > _minSpeed;

        if ((direction > 0 && _isRight == false) || (direction < 0 && _isRight))
        {
            Reflecting?.Invoke();

            _isRight = !_isRight;
        }
    }
}