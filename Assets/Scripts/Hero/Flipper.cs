using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Flipper : MonoBehaviour
{
    private Mover _mover;

    private bool _isReflected = false;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    private void OnEnable()
    {
        _mover.Reflecting += Reflect;
    }

    private void OnDisable()
    {
        _mover.Reflecting -= Reflect;
    }

    private void Reflect()
    {
        _isReflected = !_isReflected;

        float newRotationY = _isReflected ? 180f : 0f;

        transform.rotation = Quaternion.Euler(0f, newRotationY, 0f);
    }
}
