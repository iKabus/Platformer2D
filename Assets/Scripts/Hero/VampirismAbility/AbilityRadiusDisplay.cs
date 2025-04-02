using UnityEngine;

[RequireComponent(typeof(VampirismAbility))]
public class AbilityRadiusDisplay : MonoBehaviour
{
    [SerializeField] private GameObject _radiusIndicator;

    private VampirismAbility _ability;
    private int _scaleMultiplier = 2;

    private void Awake()
    {
        _ability = GetComponent<VampirismAbility>();

        InitializeIndicator();
    }

    private void InitializeIndicator()
    {
        if (_radiusIndicator != null)
        {
            float radius = _ability.GetRadius();

            _radiusIndicator.transform.localScale = new Vector3(radius * _scaleMultiplier, radius * _scaleMultiplier, 1);
            _radiusIndicator.SetActive(false);
        }
    }

    public void Show()
    {
        if (_radiusIndicator != null)
        {
            _radiusIndicator.SetActive(true);
        }
    }

    public void Hide()
    {
        if (_radiusIndicator != null)
        {
            _radiusIndicator.SetActive(false);
        }
    }
}
