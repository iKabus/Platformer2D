using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour
{
    [SerializeField, Min(5f)] private float _jumpForce;

    private Rigidbody2D _rigidBody2D;

    private void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        _rigidBody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
}
