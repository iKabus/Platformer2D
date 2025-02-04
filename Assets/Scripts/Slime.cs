using UnityEngine;

[RequireComponent (typeof(Health))]
[RequireComponent (typeof(AttackOnApproach))]
public class Slime : MonoBehaviour
{
    private Health _health;
    private AttackOnApproach _attackOnApproach;

    private void Awake()
    {
        _health = GetComponent<Health> ();
        _attackOnApproach = GetComponent<AttackOnApproach> ();
    }
}
