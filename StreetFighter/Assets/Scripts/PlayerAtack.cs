using System;
using UnityEngine;

public class PlayerAtack : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private float damage = 5f;
    private float _health = 100f;

    [SerializeField] private  EnemyMovement _enemyMovement;
    

    void Start()
    {
        _animator = GetComponent<Animator>();
        if (!_enemyMovement)
        {
            Debug.Log("asdasdfg");
        }
    }

    private void OnEnable()
    {
        _enemyMovement.HitPlayerEvent += GetGamage;
    }



    private void GetGamage()
    {
        Debug.Log("GetGamage");
        _health -= damage;
        Debug.Log(_health);
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
    
    private void OnDisable()
    {
        _enemyMovement.HitPlayerEvent -= GetGamage;
    }
}
