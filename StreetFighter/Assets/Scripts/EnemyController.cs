using System;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Vector2;

public class EnemyController : MonoBehaviour
{
    public int _health = 100;
    [SerializeField] private  PlayerMovement _playerMovement;
    private Rigidbody2D _rb;
    [SerializeField] SpriteRenderer _sre;
    private Animator _animatore;
    public event Action HitEnemyEvent;
    private Vector2 _direction;
    private bool _bIsFacingRight = true;


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
        else if(sqrDistance < 6f)
        {
            _rb.linearVelocity = _direction * 4.9f;
        }
        else
        {
            
            _direction = (_playerMovement.transform.position - transform.position).normalized;

            if (_rb.linearVelocity.x < 0f && !_bIsFacingRight)
            {
                Flip();
            }
            else if (_rb.linearVelocity.x > 0f && _bIsFacingRight)
            {
                Flip();
            }
            _rb.linearVelocity = _direction * 5.5f;
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
    public void StopMove()
    {
        _rb.linearVelocity = zero;
    }
    

    public void StopAnim()
    {
        _animatore.SetBool("Hurt", false); 
    }
    private void Flip()
    {
        _bIsFacingRight = !_bIsFacingRight;
        _sre.flipX = !_bIsFacingRight;
    }
}
