using UnityEngine;

[RequireComponent(typeof(Patrol))]
public class Chaseer : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    private Patrol _patrol;
    private Hero _hero;

    private bool _isChasing = false;

    private void Awake()
    {
        _patrol = GetComponent<Patrol>();
    }

    private void Update()
    {
        if (_isChasing && _hero != null)
        {
            Purse();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Hero>(out Hero hero))
        {
            _hero = hero;

            StartChase();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<Hero>(out _))
        {
            _isChasing = false;

            _hero = null;

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
        _isChasing = true;

        _patrol.enabled = false;
    }

    private void Purse()
    {
        if (_hero != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, _hero.transform.position, _speed * Time.deltaTime);
        }
    }
}
