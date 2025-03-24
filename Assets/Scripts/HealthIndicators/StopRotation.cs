using UnityEngine;

public class StopRotation : MonoBehaviour
{
    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void LateUpdate()
    {
        _rectTransform.rotation = Quaternion.identity;
    }
}
