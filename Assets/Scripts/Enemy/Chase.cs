using UnityEngine;

[RequireComponent(typeof(Patrol))]
public class Chase : MonoBehaviour
{
    [SerializeField] private Hero _hero;
    [SerializeField] private float _speed = 3f;

    private Patrol _patrol;

    private bool _isChasing = false;

    private void Awake()
    {
        _patrol = GetComponent<Patrol>();
    }

    private void Update()
    {
        if (_isChasing)
        {
            Purse();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.TryGetComponent<Hero>(out _))
        {
            _isChasing = false;

            _patrol.enabled = true;
        }
    }

    private void OnEnable()
    {
        _patrol.HeroDetected += StartChase;
    }

    private void OnDisable()
    {
        _patrol.HeroDetected -= StartChase;
    }

    private void StartChase()
    {
        _isChasing=true;

        _patrol.enabled = false;
    }

    private void Purse()
    {
        transform.position = Vector2.MoveTowards(transform.position, _hero.transform.position, _speed *  Time.deltaTime);
    }
}
