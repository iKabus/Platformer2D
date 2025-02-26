using UnityEngine;

[RequireComponent (typeof(Health))]
public class Picker : MonoBehaviour, IVisitor
{
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var visitable = collision.GetComponent<IVisitable>();

        if (visitable != null)
        {
            visitable.Accept(this);
        }
    }

    public void Visit(Coin coin)
    {
        Destroy(coin.gameObject);
    }

    public void Visit(Potion potion)
    {
        _health.Heal();

        Destroy(potion.gameObject);
    }
}
