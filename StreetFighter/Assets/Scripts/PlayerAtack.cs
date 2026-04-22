using System;
using UnityEngine;

public class PlayerAtack : MonoBehaviour
{
    private Animator _animator;
    public int _health = 100;
    [SerializeField] private LayerMask _enemy;
    [SerializeField] private SpriteRenderer _sr;

    public event Action HitPlayerEvent;
    void Start()
    {
        
        _animator = GetComponent<Animator>();
    }






    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetBool("Hit", true);
        }
        else
        {
            _animator.SetBool("Hit", false);
        }
    }

    public void HitPlayer()
    {
        bool Hit;
        if (_sr.flipX == false)
        {
            Hit = Physics2D.Raycast(transform.position, Vector2.right,1.5f,_enemy);
        }
        else
        {
            Hit = Physics2D.Raycast(transform.position, Vector2.left,1.5f,_enemy);
        }
        
        if (Hit)
        {
            HitPlayerEvent?.Invoke();
        }
    }
}
