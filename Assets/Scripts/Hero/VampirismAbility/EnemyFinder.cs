using UnityEngine;

public class EnemyFinder
{
    private readonly Transform _owner;
    private readonly float _radius;
    private readonly float _radiusSquared;
    private readonly LayerMask _targetLayer;
    private readonly Collider2D[] _hitsBuffer = new Collider2D[3];

    public EnemyFinder(Transform owner, float radius, LayerMask targetLayer)
    {
        _owner = owner;
        _radius = radius;
        _radiusSquared = radius * radius;
        _targetLayer = targetLayer;
    }

    public Transform FindNearest()
    {
        int hitsCount = Physics2D.OverlapCircleNonAlloc(
            _owner.position,
            _radius,
            _hitsBuffer,
            _targetLayer
        );

        Transform nearestEnemy = null;
        float minDistanceSquared = float.MaxValue;

        for (int i = 0; i < hitsCount; i++)
        {
            Collider2D hit = _hitsBuffer[i];
            if (hit.gameObject == _owner.gameObject)
                continue;

            if (hit.TryGetComponent<Health>(out _))
            {
                Vector2 direction = hit.transform.position - _owner.position;
                float distanceSquared = direction.sqrMagnitude;

                if (distanceSquared <= _radiusSquared && distanceSquared < minDistanceSquared)
                {
                    minDistanceSquared = distanceSquared;
                    nearestEnemy = hit.transform;
                }
            }
        }

        return nearestEnemy;
    }

    public void DrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_owner.position, _radius);
    }
}
