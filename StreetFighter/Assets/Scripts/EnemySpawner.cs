using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    

    [SerializeField] private Vector2 minBounds;
    [SerializeField] private Vector2 maxBounds;
    [SerializeField] private Transform player;
    private void Start()
    {
        while (true)
        {
            Invoke(nameof(SpawnEnemy),1f);
        }
    }

    private void SpawnEnemy()
    {
        Vector2 spawnPosition = new Vector2(
            Random.Range(minBounds.x, maxBounds.x),
            Random.Range(minBounds.y, maxBounds.y));
        GameObject enemyObj = Instantiate(enemyPrefab,spawnPosition,Quaternion.identity);

        EnemyAI enemy = enemyObj.GetComponent<EnemyAI>();
        enemy.Initialize(player);

    }
}

