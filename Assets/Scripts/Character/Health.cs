using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action<float, float> Changed;
    public event Action CharacterDied;

    public float MaxValue { private set; get; } = 100;
    public float CurrentValue { private set; get; }

    private void Start()
    {
        CurrentValue = MaxValue;

        Changed?.Invoke(CurrentValue, MaxValue);
    }

    public void TakeDamage(float damage)
    {
        if (damage >= 0)
        {
            CurrentValue -= damage;

            if (CurrentValue <= 0)
            {
                CurrentValue = 0;

                CharacterDied?.Invoke();
            }

            Changed?.Invoke(CurrentValue, MaxValue);
        }
    }

    public void Heal(float healValue)
    {
        if (healValue >= 0)
        {
            CurrentValue += healValue;

            if (CurrentValue > MaxValue)
            {
                CurrentValue = MaxValue;
            }

            Changed?.Invoke(CurrentValue, MaxValue);
        }
    }
}
