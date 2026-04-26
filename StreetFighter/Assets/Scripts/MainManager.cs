using System;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Setitngs _setitngs;
    [SerializeField] private UI _ui;
    [SerializeField] private EnemyController _enemyController ;
    
    [SerializeField] private  PlayerAtack _playerAtack;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private Animator _enemyAnimator;
    private void OnEnable()
    {
        _playerAtack.HitPlayerEvent += PlayerHealth;
        _enemyController.HitEnemyEvent += EnemyHealth;
    }

    private void PlayerHealth()
    {
        _enemyController._health = _health.CalcHealth(_setitngs._damage,_enemyController._health);
        Debug.Log("EnemyHp="+_enemyController._health);
        _enemyAnimator.SetBool("Hurt", true); 
        
    }
    

    private void EnemyHealth()
    {
        _playerAtack._health = _health.CalcHealth(_setitngs._damage,_playerAtack._health);
        Debug.Log("PlayerHp="+_playerAtack._health);
        _playerAnimator.SetBool("Hurt", true); 
        
        
    }

    private void OnDisable()
    {
        _playerAtack.HitPlayerEvent -= PlayerHealth;
        _enemyController.HitEnemyEvent -= EnemyHealth;
    }
}
