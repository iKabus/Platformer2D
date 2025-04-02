using UnityEngine;

public class AbilityTimer
{
    public bool IsRunning => _currentTime > 0f;
    public float CurrentTime => _currentTime;

    private float _currentTime = 0f;

    public void Start(float duration)
    {
        _currentTime = duration;
    }

    public void Update()
    {
        if (_currentTime > 0f)
        {
            _currentTime -= Time.deltaTime;
        }
    }

    public int GetRoundedTime()
    {
        return Mathf.CeilToInt(_currentTime);
    }
}
