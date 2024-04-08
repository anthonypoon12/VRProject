using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject theEnemy;
    public int minxPos;
    public int maxxPos;
    public int minzPos;
    public int maxzPos;
    public int EnemyCount;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (EnemyCount < 2)
        {
            // Randomize spawn position
            float xPos = Random.Range(minxPos, maxxPos);
            float zPos = Random.Range(minzPos, maxzPos);

            // Instantiate enemy at random position
            Instantiate(theEnemy, new Vector3(xPos, 3, zPos), Quaternion.identity);

            // Adjust spawn rate
            float spawnRate = Random.Range(0.5f, 1f);
            yield return new WaitForSeconds(spawnRate);

            EnemyCount++;
        }
    }
}