using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Jumper))]
[RequireComponent(typeof(GroundDetector))]
public class Hero : MonoBehaviour
{
    private InputReader _inputReader;
    private Mover _mover;
    private Jumper _jumper;
    private GroundDetector _groundDetector;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _mover = GetComponent<Mover>();
        _jumper = GetComponent<Jumper>();
        _groundDetector = GetComponent<GroundDetector>();
    }

    private void OnEnable()
    {
        _inputReader.Jumping += Jump;
    }

    private void OnDisable()
    {
        _inputReader.Jumping -= Jump;
    }

    private void FixedUpdate()
    {
        if (_inputReader.Direction != 0)
        {
            _mover.Move(_inputReader.Direction);
        }
    }

    private void Jump()
    {
        if (_groundDetector.IsGround)
        {
            _jumper.Jump();
        }
    }
}
