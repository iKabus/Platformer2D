using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderHealth : HealthIndicator
{
    private Slider _slider;

    protected override void Awake()
    {
        base.Awake();

        _slider = GetComponent<Slider>();
    }

    protected override void ChangeValue(float currentHealth, float maxHealth)
    {
        _slider.value = currentHealth / maxHealth;
    }
}
