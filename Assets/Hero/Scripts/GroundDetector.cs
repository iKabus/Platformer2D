using System.Collections;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _ground;
    
    public bool IsGround { get; private set; }

    private Coroutine _coroutine;

    private float _groundCheckRadius = 0.3f;

    private void Start()
    {
        _coroutine = StartCoroutine(CheckingGround());
    }

    private void OnDestroy()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    private IEnumerator CheckingGround()
    {
        var wait = new WaitForSeconds(0.1f);

        while (enabled)
        {
            CheckGround();

            yield return wait;
        }
    }

    private void CheckGround()
    {
        IsGround = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _ground);
    }
}
