using System;
using UnityEngine;

[RequireComponent(typeof(GroundDetector))]
public class InputReader : MonoBehaviour
{
    public const string CommandHorizontal = "Horizontal";

    public event Action Jumping;

    public float Direction { get; private set; } = 0;

    private GroundDetector _groundDetector;

    private void Awake()
    {
        _groundDetector = GetComponent<GroundDetector>();
    }

    private void Update()
    {
        Direction = Input.GetAxis(CommandHorizontal);

        if (Input.GetKeyDown(KeyCode.Space) && _groundDetector.IsGround)
        {
            Jumping?.Invoke();
        }
    }
}
