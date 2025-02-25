using UnityEngine;

[RequireComponent(typeof(HeroAnimator))]
public class HeroAnimationController : MonoBehaviour
{
    private HeroAnimator _heroAnimator;
    private Mover _mover;

    private void Awake()
    {
        _heroAnimator = GetComponent<HeroAnimator>();
        _mover = GetComponent<Mover>();
    }

    private void Update()
    {
        if (_mover.IsMove)
        {
            _heroAnimator.PlayMove();
        }
        else
        {
            _heroAnimator.PlayIdle();
        }
    }
}
