using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SmoothSliderHealth : HealthIndicator
{
    private Slider _slider;

    private float _smoothSpeed = 0.5f;
    private float _targetValue;

    private Coroutine _coroutine;

    protected override void Awake()
    {
        base.Awake();

        _slider = GetComponent<Slider>();
    }

    protected override void ChangeValue(float currentHealth, float maxHealth)
    {
        _targetValue = currentHealth / maxHealth;

        if(_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(SmoothUpdateSlider());
    }

    private IEnumerator SmoothUpdateSlider()
    {
        float _value = 0.001f;

        while (Mathf.Abs(_slider.value - _targetValue) > _value)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, _smoothSpeed * Time.deltaTime);

            yield return null;
        }

        _slider.value = _targetValue;

        _coroutine = null;
    }
}
