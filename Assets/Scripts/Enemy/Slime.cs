using System;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public event Action HeroEnter;
    public event Action HeroLeave;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Hero>(out _))
        {
            HeroEnter?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<Hero>(out _))
        {
            HeroLeave?.Invoke();
        }
    }
}
