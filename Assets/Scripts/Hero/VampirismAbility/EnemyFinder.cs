using UnityEngine;

public class EnemyFinder
{
    private readonly Transform _owner;
    private readonly float _radius;

    public Transform NearestEnemy { get; private set; }

    public EnemyFinder(Transform owner, float radius)
    {
        _owner = owner;
        _radius = radius;
    }

    public void FindNearest()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(_owner.position, _radius);

        float minDistance = float.MaxValue;

        NearestEnemy = null;

        foreach (var hit in hits)
        {
            if (hit.gameObject == _owner.gameObject) continue;

            if (hit.TryGetComponent<Health>(out Health enemy))
            {
                float distance = Vector2.Distance(_owner.position, hit.transform.position);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    NearestEnemy = hit.transform;
                }
            }
        }
    }

    public void DrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_owner.position, _radius);
    }
}
