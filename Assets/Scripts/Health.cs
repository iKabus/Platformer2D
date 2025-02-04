using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100;

    private float _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }
    
    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public void TakeHealth()
    {
        _currentHealth += 50;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
