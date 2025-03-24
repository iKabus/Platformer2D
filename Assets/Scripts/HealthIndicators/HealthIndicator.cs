using UnityEngine;

public abstract class HealthIndicator : MonoBehaviour
{
    [SerializeField] private Health _health;

    protected Health Health { get { return _health; } }

    protected virtual void Awake()
    {
        Health.Changed += ChangeValue;
    }

    protected void OnDestroy()
    {
        Health.Changed -= ChangeValue;
    }

    protected abstract void ChangeValue(float currentHealth, float maxHealth);
}
