using UnityEngine;
using System.Collections;

public class VampirismAbility : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _abilityDuration = 6f;
    [SerializeField] private float _cooldownDuration = 4f;
    [SerializeField] private float _damagePerSecond = 10f;
    [SerializeField] private float _healPerSecond = 5f;
    [SerializeField] private float _radius = 5f;

    private AbilityTimer _timer;
    private Health _playerHealth;
    private CooldownDisplay _cooldownDisplay;
    private AbilityRadiusDisplay _radiusDisplay;
    private EnemyFinder _enemyFinder;

    private bool _isAbilityActive = false;
    private bool _isOnCooldown = false;

    private Coroutine _abilityCoroutine;

    public float GetRadius() => _radius;

    private void Awake()
    {
        _playerHealth = GetComponent<Health>();
        _cooldownDisplay = GetComponent<CooldownDisplay>();
        _radiusDisplay = GetComponent<AbilityRadiusDisplay>();
        _enemyFinder = new EnemyFinder(transform, _radius);

        _timer = new AbilityTimer();
    }

    private void Update()
    {
        _cooldownDisplay.UpdateDisplay(_timer, _isAbilityActive, _isOnCooldown);
    }

    public void HandleAbility()
    {
        if (!_isAbilityActive && !_isOnCooldown)
        {
            if (_abilityCoroutine != null)
            {
                StopCoroutine(_abilityCoroutine);
            }

            _abilityCoroutine = StartCoroutine(AbilityCoroutine());
        }
    }

    private IEnumerator AbilityCoroutine()
    {
        _isAbilityActive = true;
        _radiusDisplay.Show();
        _timer.Start(_abilityDuration);

        while (_timer.IsRunning)
        {
            _enemyFinder.FindNearest();

            if (_enemyFinder.NearestEnemy != null)
            {
                Health enemyHealth = _enemyFinder.NearestEnemy.GetComponent<Health>();

                if (enemyHealth != null)
                {
                    float damage = _damagePerSecond * Time.deltaTime;
                    enemyHealth.TakeDamage(damage);
                    _playerHealth.Heal(damage * (_healPerSecond / _damagePerSecond));
                }
            }

            _timer.Update();
            yield return null;
        }

        _isAbilityActive = false;
        _radiusDisplay.Hide();

        _isOnCooldown = true;
        _timer.Start(_cooldownDuration);

        while (_timer.IsRunning)
        {
            _timer.Update();
            yield return null;
        }

        _isOnCooldown = false;
    }

    private void OnDrawGizmosSelected()
    {
        _enemyFinder?.DrawGizmos();
    }
}