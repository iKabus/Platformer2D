using UnityEngine;

[RequireComponent (typeof(Health))]
public class CharacterDestroyer : MonoBehaviour
{
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health> ();
    }

    private void OnEnable()
    {
        _health.OnCharacterDied += Delete;
    }

    private void OnDisable()
    {
        _health.OnCharacterDied -= Delete;
    }

    private void Delete()
    {
        Destroy(gameObject);
    }
}
