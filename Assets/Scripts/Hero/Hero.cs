using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Jumper))]
[RequireComponent(typeof(GroundDetector))]
[RequireComponent(typeof(VampirismAbility))]
public class Hero : MonoBehaviour
{
    private InputReader _inputReader;
    private Mover _mover;
    private Jumper _jumper;
    private GroundDetector _groundDetector;
    private VampirismAbility _vampirismAbility;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _mover = GetComponent<Mover>();
        _jumper = GetComponent<Jumper>();
        _groundDetector = GetComponent<GroundDetector>();
        _vampirismAbility = GetComponent<VampirismAbility>();
    }

    private void OnEnable()
    {
        _inputReader.Jumping += Jump;
        _inputReader.Vampiring += SuckBlood;
    }

    private void OnDisable()
    {
        _inputReader.Jumping -= Jump;
        _inputReader.Vampiring -= SuckBlood;
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

    private void SuckBlood()
    {
        _vampirismAbility.HandleAbility();
    }
}
