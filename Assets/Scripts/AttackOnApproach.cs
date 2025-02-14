using UnityEngine;

public class AttackOnApproach : MonoBehaviour
{
    [SerializeField] private float _attackRange = 5f;
    [SerializeField] private float _damage = 10;
    [SerializeField] private float _attackCooldown = 1f;
    
    private float lastAttackTime;

    private void Update()
    {
        if(Time.time -  lastAttackTime >= _attackCooldown)
        {
            Attack();
            lastAttackTime = Time.time;
        }
    }

    private void Attack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, _attackRange);

        foreach (Collider2D enemy in enemies)
        {
            if (enemy.gameObject != gameObject)
            {
                Health enemyHealth = enemy.GetComponent<Health>();

                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(_damage);
                }
            }
        }
    }
}
