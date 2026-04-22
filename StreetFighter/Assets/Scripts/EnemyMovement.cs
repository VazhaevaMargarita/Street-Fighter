using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
[SerializeField] private float speed = 6f;
    [SerializeField] float raycastDistance = 5f;
    [SerializeField] float raycastHitDistance = 0.5f;
    [SerializeField] LayerMask _Player;
    private Rigidbody2D _rbe;
    private Animator _animatore;
    private Vector2 _movemente;
    private bool _bIsRight = true;
    [SerializeField] SpriteRenderer _sre;
    private PlayerAtack _playerAtack;
    

    
    
    public event Action HitPlayerEvent;
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rbe = GetComponent<Rigidbody2D>();
        _animatore = GetComponent<Animator>();
        _animatore.SetFloat("Move", 0f); 
        _animatore.SetBool("Hit", false);
        _playerAtack = GetComponent<PlayerAtack>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        bool hitl = Physics2D.Raycast(transform.position, Vector2.left,raycastDistance,_Player);
        Debug.DrawRay(transform.position, Vector2.left*raycastDistance, hitl? Color.green:Color.red);
        if (hitl)
        {
            _movemente = Vector2.left;
            _animatore.SetFloat("Move", 1f);
            _rbe.linearVelocity = new Vector2(_movemente.x * speed, _rbe.linearVelocity.y);
            
        }
        bool hittohitl = Physics2D.Raycast(transform.position, Vector2.left,raycastHitDistance,_Player);
        if (hittohitl)
        { 
            _animatore.SetFloat("Move", 0f); 
            _animatore.SetBool("Hit", true); 
            _rbe.linearVelocity = new Vector2(0f, _rbe.linearVelocity.y);
            

        }
        else
        {
            _animatore.SetBool("Hit", false);

        }
        
        bool hitr = Physics2D.Raycast(transform.position, Vector2.right,raycastDistance,_Player);
        Debug.DrawRay(transform.position, Vector2.right*raycastDistance, hitr? Color.green:Color.red);
        if (hitr)
        {
            _movemente = Vector2.right;
            _animatore.SetFloat("Move", 1f);
            _rbe.linearVelocity = new Vector2(_movemente.x * speed, _rbe.linearVelocity.y);
            
        }
        bool hittohitr = Physics2D.Raycast(transform.position, Vector2.right,raycastHitDistance,_Player);
        if (hittohitr)
        { 
            _animatore.SetFloat("Move", 0f); 
            _animatore.SetBool("Hit", true); 
            _rbe.linearVelocity = new Vector2(0f, _rbe.linearVelocity.y);
        }
        else
        {
            _animatore.SetBool("Hit", false); 
            
        }

        if ((hitl == false) && (hitr== false))
        {
            _animatore.SetFloat("Move", 0f); 
            _rbe.linearVelocity = new Vector2(0f, _rbe.linearVelocity.y);
        }
        
        
        if (_movemente.x > 0 && _bIsRight)
        {
            Flip();
        }
        else if (_movemente.x < 0 && !_bIsRight)
        { 
            Flip();
        }
    }
    
    private void Flip()
    {
        _bIsRight = !_bIsRight;
        _sre.flipX = !_bIsRight;
    }


    public void AtackPlayer()
    {
        Debug.Log("AtackPlayer");
        bool Hitt;
        if (_bIsRight == true)
        {
            Debug.Log(_rbe);
            Hitt = Physics2D.Raycast(transform.position, Vector2.right,raycastHitDistance,_Player);
        }
        else 
        {
            Debug.Log('a');
            Hitt = Physics2D.Raycast(transform.position, Vector2.left,raycastHitDistance,_Player);
        }
        
        if (Hitt)
        {
            Debug.Log("HitPlayer");
            HitPlayerEvent?.Invoke();
        }
    }
    
}
