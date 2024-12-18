using System;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public const String CommandHorizontal = "Horizontal";
    
    [SerializeField, Min(0.1f)] private float _speed;
    [SerializeField, Min(5f)] private float _jumpForce;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _ground;
    
    public event Action Moving;
    public event Action Stoping;
    public event Action Reflecting;
    
    private Rigidbody2D _rigidBody2D;

    private float _minSpeed = 0.1f;
    private float _groundCheckRadius = 0.3f;

    private Vector2 _inputVector;
    
    private bool _isRight = true;
    private bool _onGround = true;

    private void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
        CheckGround();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _onGround)
        {
            _rigidBody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void Move()
    {
        _inputVector.x = Input.GetAxis(CommandHorizontal);
        
        _rigidBody2D.linearVelocity = new Vector2(_inputVector.x * _speed, _rigidBody2D.linearVelocity.y);
        
        if (Mathf.Abs(_inputVector.x) > _minSpeed)
        {
            Moving?.Invoke();
        }
        else
        {
            Stoping?.Invoke();
        }
        
        if((_inputVector.x > 0 && _isRight == false) || (_inputVector.x < 0 && _isRight))
        {
            Reflecting?.Invoke();
            
            _isRight = !_isRight;
        }
    }

    private void CheckGround()
    {
        _onGround = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _ground);
    }
}