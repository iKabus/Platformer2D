using TMPro;
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

    [Header("Visuals")]
    [SerializeField] private GameObject _radiusIndicator;
    [SerializeField] private TextMeshProUGUI _cooldownText;

    private bool _isAbilityActive = false;
    private bool _isOnCooldown = false;
    private float _currentTimer = 0f;

    private Health _playerHealth;
    private Transform _nearestEnemy;
    private Coroutine _abilityCoroutine;

    private void Awake()
    {
        int value = 2;

        _playerHealth = GetComponent<Health>();

        _radiusIndicator.transform.localScale = new Vector3(_radius * value, _radius * value, 1);
        _radiusIndicator.SetActive(false);
    }

    private void Update()
    {
        UpdateCooldownText();
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
        _radiusIndicator.SetActive(true);
        _currentTimer = _abilityDuration;

        while (_currentTimer > 0f)
        {
            FindNearestEnemy();

            if (_nearestEnemy != null)
            {
                Health enemyHealth = _nearestEnemy.GetComponent<Health>();

                if (enemyHealth != null)
                {
                    float damage = _damagePerSecond * Time.deltaTime;
                    enemyHealth.TakeDamage(damage);
                    _playerHealth.Heal(damage * (_healPerSecond / _damagePerSecond));
                }
            }

            _currentTimer -= Time.deltaTime;

            yield return null;
        }

        _isAbilityActive = false;
        _nearestEnemy = null;
        _radiusIndicator.SetActive(false);

        _isOnCooldown = true;
        _currentTimer = _cooldownDuration;

        while (_currentTimer > 0f)
        {
            _currentTimer -= Time.deltaTime;

            yield return null;
        }

        _isOnCooldown = false;
    }

    private void FindNearestEnemy()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _radius);

        float minDistance = float.MaxValue;
        _nearestEnemy = null;

        foreach (var hit in hits)
        {
            if (hit.gameObject == gameObject) continue;

            if (hit.TryGetComponent<Health>(out Health enemy))
            {
                float distance = Vector2.Distance(transform.position, hit.transform.position);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    _nearestEnemy = hit.transform;
                }
            }
        }
    }

    private void UpdateCooldownText()
    {
        if (_isAbilityActive)
        {
            _cooldownText.text = Mathf.Ceil(_currentTimer).ToString();
            _cooldownText.color = Color.red;
        }
        else if (_isOnCooldown)
        {
            _cooldownText.text = Mathf.Ceil(_currentTimer).ToString();
            _cooldownText.color = Color.yellow;
        }
        else
        {
            _cooldownText.text = "READY";
            _cooldownText.color = Color.green;
        }

        _cooldownText.transform.rotation = Quaternion.identity;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}