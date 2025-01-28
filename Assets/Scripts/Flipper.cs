using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(Mover))]
public class Flipper : MonoBehaviour
{
    private Mover _mover;

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
        int direction = -1;

        transform.localScale *= new Vector2(direction, 1);
    }
}
