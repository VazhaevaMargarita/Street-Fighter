using UnityEngine;

public class MainManager : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Setitngs _setitngs;
    [SerializeField] private UI _ui;
    [SerializeField] private EnemyController _enemyController ;
    
    [SerializeField] private  PlayerAtack _playerAtack;
    
    private void OnEnable()
    {
        _playerAtack.HitPlayerEvent += PlayerHealth;
    }

    private void PlayerHealth()
    {
        _enemyController._health = _health.CalcHealth(_setitngs._damage,_enemyController._health);
        Debug.Log(_enemyController._health);
        
    }

    private void OnDisable()
    {
        _playerAtack.HitPlayerEvent -= PlayerHealth;
    }
}
