using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Vector2 _playerPosition;
    [SerializeField] private Vector2 _cameraPosition;
    [SerializeField] private Camera _camera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out var playerScript))
        {
            _camera.transform.position = new Vector3(_cameraPosition.x, _cameraPosition.y, _camera.transform.position.z);
            collision.gameObject.transform.position = new Vector3(_playerPosition.x, _playerPosition.y, collision.gameObject.transform.position.z);
        }
    }
}
