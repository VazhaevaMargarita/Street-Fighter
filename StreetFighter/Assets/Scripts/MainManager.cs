using System;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Setitngs _setitngs;
    [SerializeField] private UIManager _ui;
    private EnemyController _enemyController ;
    [SerializeField] private  PlayerMovement _pplayerMovement;
    [SerializeField] private  PlayerAtack _playerAtack;
    [SerializeField] private Animator _playerAnimator;
    private Animator _enemyAnimator;
    [SerializeField]private GameObject prefab;

    private void Awake()
    {
        _enemyController = prefab.GetComponent<EnemyController>();
        _enemyAnimator = prefab.GetComponent<Animator>();
        _enemyController._playerMovement = _pplayerMovement;
    }

    private void OnEnable()
    {
        _playerAtack.HitPlayerEvent += PlayerAtack;
        _enemyController.HitEnemyEvent += EnemyAtack;
    }

    
    private void PlayerAtack()
    {
        _enemyController._health = _health.CalcHealth(_setitngs._damage,_enemyController._health);
        Debug.Log("EnemyHp="+_enemyController._health);
        _enemyAnimator.SetBool("Hurt", true);
        _enemyController.SetHealthEn(_enemyController._health,100f);
        
    }
    

    private void EnemyAtack()
    {
        _playerAtack._health = _health.CalcHealth(_setitngs._damage,_playerAtack._health);
        Debug.Log("PlayerHp="+_playerAtack._health);
        _playerAnimator.SetBool("Hurt", true); 
        _ui.SetHealthPl(_playerAtack._health,100f);
        
    }

    private void OnDisable()
    {
        _playerAtack.HitPlayerEvent -= PlayerAtack;
        _enemyController.HitEnemyEvent -= EnemyAtack;
    }
}
