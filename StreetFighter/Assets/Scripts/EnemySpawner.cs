using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefab;
    
    public float minX = -10f, maxX = 10f;
    public float minY = 0f, maxY = 5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (var i = 0; i < 10; i++)
        {
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            Vector2 newPos= new Vector2(randomX, randomY);
            Instantiate(prefab, newPos, Quaternion.identity);
        }
    }
}
