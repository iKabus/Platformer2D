using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxValue = 100;

    private float _currentValue;
    private float _healValue = 50;

    public event Action OnCharacterDied;

    private void Start()
    {
        _currentValue = _maxValue;
    }
    
    public void TakeDamage(float damage)
    {
        _currentValue -= damage;

        if (_currentValue <= 0)
        {
            OnCharacterDied?.Invoke();
        }
    }

    public void Heal()
    {
        _currentValue += _healValue;

        if (_currentValue > _maxValue)
        {
            _currentValue = _maxValue;
        }
    }
}
