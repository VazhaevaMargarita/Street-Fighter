using System;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Vector2;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    public int _health = 100;
    public PlayerMovement _playerMovement;
    [SerializeField] SpriteRenderer _sre;
    private Animator _animatore;
    public event Action HitEnemyEvent;
    private Vector2 _direction;
    private bool _bIsFacingRight = true;
    [SerializeField] private float _speed;
    [SerializeField] private float _hitDistance = 10f;
    [SerializeField] private float _stopDistance = 1f;
    [SerializeField] private GameObject _enemy;

    private void Start()
    {
        _speed = Random.Range(3f, 6f);
        _animatore = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float sqrDistance = (transform.position - _playerMovement.transform.position).sqrMagnitude;
        
        if (sqrDistance < _hitDistance * _hitDistance)
        {
            Vector3 enemyPos = transform.position;
            Vector3 playerPos = _playerMovement.transform.position;

            float distance = Vector3.Distance(enemyPos, playerPos);
            if (distance <= _stopDistance)
            {
                _animatore.SetFloat("Move", 0f); 
                _animatore.SetBool("Hit", true); 
                return;
            }
            
            if (Mathf.Abs(playerPos.y - enemyPos.y)>0.05f)
            {
                enemyPos.y = Mathf.MoveTowards(enemyPos.y, playerPos.y, _speed*Time.deltaTime);
            }
            else
            {
                // Потом идём к игроку
                enemyPos.x = Mathf.MoveTowards(enemyPos.x, playerPos.x, _speed*Time.deltaTime);
                if (playerPos.x - enemyPos.x > 0&&_bIsFacingRight)
                {
                    Flip();
                }
                else if (playerPos.x - enemyPos.x < 0&& !_bIsFacingRight)
                {
                    Flip();
                }
            }

            transform.position = enemyPos;
        }
        
        /*
        float sqrDistance = (transform.position - _playerMovement.transform.position).sqrMagnitude;

        if (sqrDistance < _hitDistance)
        {
            _animatore.SetFloat("Move", 0f); 
            _animatore.SetBool("Hit", true); 
        }
        else if(sqrDistance < 6f)
        {
            _rb.linearVelocity = _direction * _speed;
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
            _rb.linearVelocity = _direction * _speed;
            _animatore.SetFloat("Move", 1f); 
            _animatore.SetBool("Hit", false); */

        
        
    }

    private void Update()
    {
        if (_health <= 0)
        {
            _animatore.SetFloat("Move", 0f); 
            _animatore.SetBool("Hurt", true); 
            Destroy(_enemy,0.5f);
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
