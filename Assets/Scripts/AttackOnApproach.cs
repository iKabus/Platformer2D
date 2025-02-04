using UnityEngine;

public class AttackOnApproach : MonoBehaviour
{
    [SerializeField] private float _attackRange = 5f;
    [SerializeField] private float _damage = 10;
    [SerializeField] private float _attackCooldown = 1f;

    private float lastAttackTime;

    private void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            if (enemy != gameObject)
            {
                float distance = Vector2.Distance(transform.position, enemy.transform.position);

                if (distance <= _attackRange && Time.time > lastAttackTime + _attackCooldown)
                {
                    Attack(enemy);
                    lastAttackTime = Time.time;
                }
            }
        }
    }

    private void Attack(GameObject target)
    {
        Health targetHealth = target.GetComponent<Health>();

        if (targetHealth != null)
        {
            targetHealth.TakeDamage(_damage);

            Debug.Log(gameObject.name + " атаковал " + target.name + " и нанес " + _damage + " урона.");
        }
    }
}
