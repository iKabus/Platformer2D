using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Jumper))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(AttackOnApproach))]
public class Hero : MonoBehaviour
{
    private InputReader _inputReader;
    private Mover _mover;
    private Jumper _jumper;
    private Health _health;
    private AttackOnApproach _attackOnApproach;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _mover = GetComponent<Mover>();
        _jumper = GetComponent<Jumper>();
        _health = GetComponent<Health>();
        _attackOnApproach = GetComponent<AttackOnApproach>();
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
        _jumper.Jump();
    }
}
