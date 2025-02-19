using UnityEngine;

[RequireComponent (typeof(Health))]
public class Picker : MonoBehaviour
{
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Coin>())
        {
            Destroy(collision.gameObject);
        }

        if (collision.GetComponent<Potion>())
        {
            _health.Heal();

            Destroy(collision.gameObject);
        }
    }
}
