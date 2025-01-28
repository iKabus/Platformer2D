using UnityEngine;

public class InputReader : MonoBehaviour
{
    public const string CommandHorizontal = "Horizontal";

    private bool _isJump;

    public float Direction { get; private set; } = 0;

    private void Update()
    {
        Direction = Input.GetAxis(CommandHorizontal);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isJump = true;
        }
    }

    public bool GetIsJump() => GetBoolAsTrigger(ref _isJump);

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }
}
