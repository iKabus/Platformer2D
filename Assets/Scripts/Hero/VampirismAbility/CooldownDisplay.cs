using UnityEngine;
using TMPro;

public class CooldownDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _cooldownText;

    private float _currentCooldown;
    private bool _isActive;
    private bool _isOnCooldown;

    public void StartAbility(float duration)
    {
        _isActive = true;
        _currentCooldown = duration;
    }

    public void StartCooldown(float cooldownDuration)
    {
        _isActive = false;
        _isOnCooldown = true;
        _currentCooldown = cooldownDuration;
    }

    public void ResetCooldown()
    {
        _isActive = false;
        _isOnCooldown = false;
        _currentCooldown = 0f;
    }

    private void Update()
    {
        if (_isActive || _isOnCooldown)
        {
            _currentCooldown -= Time.deltaTime;

            if (_currentCooldown <= 0f)
            {
                ResetCooldown();
            }
        }

        UpdateText();
    }

    private void UpdateText()
    {
        if (_isActive)
        {
            _cooldownText.text = Mathf.CeilToInt(_currentCooldown).ToString();
            _cooldownText.color = Color.red;
        }
        else if (_isOnCooldown)
        {
            _cooldownText.text = Mathf.CeilToInt(_currentCooldown).ToString();
            _cooldownText.color = Color.yellow;
        }
        else
        {
            _cooldownText.text = "READY";
            _cooldownText.color = Color.green;
        }

        _cooldownText.transform.rotation = Quaternion.identity;
    }
}
