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
    private AbilityRadiusDisplay _radiusDisplay;
    private EnemyFinder _enemyFinder;
    private Transform _enemy;
    private CooldownDisplay _cooldownDisplay;

    private bool _isAbilityActive = false;
    private bool _isOnCooldown = false;

    private Coroutine _abilityCoroutine;

    public float GetRadius() => _radius;

    private void Awake()
    {
        _playerHealth = GetComponent<Health>();
        _radiusDisplay = GetComponent<AbilityRadiusDisplay>();
        _cooldownDisplay = GetComponent<CooldownDisplay>();

        LayerMask enemyLayer = LayerMask.GetMask("Enemy");
        
        _enemyFinder = new EnemyFinder(transform, _radius, enemyLayer);

        _timer = new AbilityTimer();
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

        _cooldownDisplay.StartAbility(_abilityDuration);

        _radiusDisplay.Show();
        
        _timer.Start(_abilityDuration);

        while (_timer.IsRunning)
        {
            _enemy = _enemyFinder.FindNearest();

            if (_enemy != null)
            {
                Health enemyHealth = _enemy.GetComponent<Health>();

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
        _cooldownDisplay.StartCooldown(_cooldownDuration);
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