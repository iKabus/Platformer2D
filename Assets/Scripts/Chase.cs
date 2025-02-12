using UnityEngine;

[RequireComponent(typeof(Patrol))]
public class Chase : MonoBehaviour
{
    [SerializeField] Hero _hero;
    [SerializeField] float _speed = 3f;
    [SerializeField] float _distance = 10f;

    private Patrol _patrol;

    private Vector2 _startPosition;

    private void Awake()
    {
        _patrol = GetComponent<Patrol>();
    }

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        Chasing();
    }

    private void Chasing()
    {
        if (_hero != null)
        {
            float distanceToHero = Vector2.Distance(transform.position, _hero.transform.position);

            if (distanceToHero < _distance)
            {
                _patrol.enabled = false;

                Vector2 direction = (_hero.transform.position - transform.position).normalized;

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
    }
}
