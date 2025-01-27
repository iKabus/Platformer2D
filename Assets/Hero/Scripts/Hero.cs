using UnityEngine;

[RequireComponent (typeof(InputReader))]
[RequireComponent (typeof(Mover))]
[RequireComponent (typeof(GroundDetector))]

public class Hero : MonoBehaviour
{
    private GroundDetector _groundDetector;
    private InputReader _inputReader;
    private Mover _mover;

    private void Start()
    {
        _groundDetector = GetComponent<GroundDetector>();
        _inputReader = GetComponent<InputReader>();
        _mover = GetComponent<Mover>();
    }

    private void FixedUpdate()
    {
        if (_inputReader.Direction != 0)
        {
            _mover.Move(_inputReader.Direction);
        }

        if(_inputReader.GetIsJump() && _groundDetector.IsGround)
        {
            _mover.Jump();
        }
    }
}
