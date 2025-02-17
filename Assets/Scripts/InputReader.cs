using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public const string CommandHorizontal = "Horizontal";
    
    public float Direction { get; private set; } = 0;
    
    public event Action Jumping;

    private void Update()
    {
        Direction = Input.GetAxis(CommandHorizontal);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jumping?.Invoke();
        }
    }
}
