using UnityEngine;
using UnityEngine.UIElements;

public class UnitHealth : MonoBehaviour
{
    [SerializeField] private Vector2 healthBarOffset = new Vector2(-5.25f, (-1.3f));
    [SerializeField] private UIDocument healthBarUxml;
    [SerializeField] private Camera mainCamera;

    private VisualElement _healthBar;
    private Vector3 _lastFollowPosition;
    public const int MaxWidth = 25;

    public VisualElement HealthBar => _healthBar;

    private void Awake()
    {
        _healthBar = healthBarUxml.rootVisualElement;
    }

    private void Start()
    {
        UpdatePosition();
    }
    

    private void LateUpdate()
    {
        if (transform.localPosition != _lastFollowPosition)
        {
            UpdatePosition();
        }
    }

    private void UpdatePosition()
    {
        Vector2 newPosition =
            RuntimePanelUtils.CameraTransformWorldToPanel(_healthBar.panel,
                transform.localPosition + (Vector3) healthBarOffset, mainCamera);

        _lastFollowPosition = newPosition;

        _healthBar.style.left = newPosition.x;
        _healthBar.style.top = newPosition.y;
    }
}