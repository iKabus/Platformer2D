using TMPro;
using UnityEngine;

public class CooldownDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _cooldownText;

    public void UpdateDisplay(AbilityTimer timer, bool isAbilityActive, bool isOnCooldown)
    {
        if (isAbilityActive)
        {
            _cooldownText.text = timer.GetRoundedTime().ToString();
            _cooldownText.color = Color.red;
        }
        else if (isOnCooldown)
        {
            _cooldownText.text = timer.GetRoundedTime().ToString();
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
