using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Patrol))]
[RequireComponent(typeof(Slime))]
public class Chase : MonoBehaviour
{
    [SerializeField] private Hero _hero;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _distance = 10f;

    private Patrol _patrol;
    private Slime _slime;

    private Vector2 _startPosition;

    private Coroutine _coroutine;

    private void Awake()
    {
        _patrol = GetComponent<Patrol>();
        _slime = GetComponent<Slime>();
    }

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void OnEnable()
    {
        _slime.HeroEnter += StartChasing;
        _slime.HeroEnter += StopChasing;
    }

    private void OnDisable()
    {
        _slime.HeroEnter -= StartChasing;
        _slime.HeroEnter -= StopChasing;
    }

    private void StartChasing()
    {
        _coroutine = StartCoroutine(ChasingForHero());
    }

    private void StopChasing()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    private IEnumerator ChasingForHero()
    {
        while (_hero != null)
        {
            float distanceToHero = Vector2.Distance(transform.position, _hero.transform.position);

            if (distanceToHero < _distance)
            {
                _patrol.enabled = false;

                transform.position = Vector2.MoveTowards(transform.position, _hero.
                    transform.position, _speed * Time.deltaTime);
            }
            else if (_patrol.enabled == false && (Vector2.Distance(transform.position, _startPosition) > 0.1f))
            {
                transform.position = Vector2.MoveTowards(transform.position, _startPosition, _speed * Time.deltaTime);
            }
            else
            {
                _patrol.enabled = true;
            }
        }

        yield return null;
    }
}
