using System;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxDistation;
    
    private float _startCoordinate;

    private void Start()
    {
        _startCoordinate = transform.position.x;
    }

    private void Update()
    {
        float xCoordinate = Mathf.PingPong(Time.time * _speed, _maxDistation);
        
        transform.position = new Vector2(_startCoordinate - xCoordinate, transform.position.y);
    }
}
