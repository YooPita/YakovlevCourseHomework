using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class ClickObject : MonoBehaviour
{
    private Vector2 MousePosition => _camera.ScreenToWorldPoint(Input.mousePosition);

    private Collider2D _collider;
    private Camera _camera;

    protected abstract void OnClick();

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _collider.OverlapPoint(MousePosition))
            OnClick();
    }
}
