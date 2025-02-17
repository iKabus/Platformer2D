using System.Collections;
using UnityEngine;

public class AttackOnApproach : MonoBehaviour
{
    [SerializeField] private float _damage = 10;
    [SerializeField] private float _attackCooldown = 1f;

    private Coroutine _coroutine;

    private Health _targetHealth;

    private bool _isAttacking = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Health>(out Health enemy))
        {
            _targetHealth = enemy;

            if (_isAttacking == false)
            {
               _coroutine = StartCoroutine(Attacking());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<Health>(out Health enemy) && enemy == _targetHealth)
        {
            StopCoroutine(_coroutine);

            _isAttacking = false;
            _targetHealth = null;
        }
    }

    private void OnDestroy()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    private IEnumerator Attacking()
    {
        var wait = new WaitForSeconds(_attackCooldown);

        _isAttacking = true;

        while (_targetHealth != null)
        {
            _targetHealth.TakeDamage(_damage);

            yield return wait;
        }

        _isAttacking = false;
    }
}
