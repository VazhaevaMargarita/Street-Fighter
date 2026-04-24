using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int _health = 100;
    [SerializeField] private  PlayerMovement _playerMovement;
    private Rigidbody2D _rb;
    [SerializeField] SpriteRenderer _sre;
    private Animator _animatore;
    public event Action HitEnemyEvent;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animatore = GetComponent<Animator>();
    }

    private void Update()
    {
        
        
        float sqrDistance = (transform.position - _playerMovement.transform.position).sqrMagnitude;

        if (sqrDistance < 4f)
        {
            _animatore.SetFloat("Move", 0f); 
            _animatore.SetBool("Hit", true); 
        }
        else
        {
            Vector3 direction = (_playerMovement.transform.position - transform.position).normalized;

            _rb.linearVelocity = direction * 5f;
            _animatore.SetFloat("Move", 1f); 
            _animatore.SetBool("Hit", false); 
        }
        
    }
    
    public void HitEnemy()
    {
        
        float sqrDistance = (transform.position - _playerMovement.transform.position).sqrMagnitude;

        if (sqrDistance < 3f)
        {
            HitEnemyEvent?.Invoke();
        }
    }
    
}
