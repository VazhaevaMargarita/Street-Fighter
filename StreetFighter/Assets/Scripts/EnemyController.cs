using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int _health = 100;
    [SerializeField] private  PlayerMovement _playerMovement;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rb.linearVelocity = new Vector2(_playerMovement.transform.position.x, _playerMovement.transform.position.y );
    }
}
