using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;

    private bool _movingToB = true;

    private void Update()
    {
        Transform target = _movingToB ? _pointB : _pointA;

        transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
    
        if(Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            _movingToB = !_movingToB;
        }
    }
}
