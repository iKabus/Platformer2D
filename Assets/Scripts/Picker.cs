using UnityEngine;

public class Picker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Coin>())
        {
            Destroy(collision.gameObject);
        }
    }
}
