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
        _health.CharacterDied += Delete;
    }

    private void OnDisable()
    {
        _health.CharacterDied -= Delete;
    }

    private void Delete()
    {
        Destroy(gameObject);
    }
}
