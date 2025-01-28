using UnityEngine;

[RequireComponent (typeof(InputReader))]
[RequireComponent (typeof(Mover))]
[RequireComponent (typeof(GroundDetector))]
[RequireComponent (typeof(Jumper))]
public class Hero : MonoBehaviour
{
    private GroundDetector _groundDetector;
    private InputReader _inputReader;
    private Mover _mover;
    private Jumper _jumper;

    private void Awake()
    {
        _groundDetector = GetComponent<GroundDetector>();
        _inputReader = GetComponent<InputReader>();
        _mover = GetComponent<Mover>();
        _jumper = GetComponent<Jumper>();
    }

    private void FixedUpdate()
    {
        if (_inputReader.Direction != 0)
        {
            _mover.Move(_inputReader.Direction);
        }

        if(_inputReader.GetIsJump() && _groundDetector.IsGround)
        {
            _jumper.Jump();
        }
    }
}
