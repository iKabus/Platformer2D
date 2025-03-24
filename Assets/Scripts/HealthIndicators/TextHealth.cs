using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextHealth : HealthIndicator
{
    private Text _text;

    protected override void Awake()
    {
        base.Awake();

        _text = GetComponent<Text>();
    }

    protected override void ChangeValue(float currentHealth, float maxHealth)
    {
        _text.text = $"{currentHealth}/{maxHealth}";
    }
}
