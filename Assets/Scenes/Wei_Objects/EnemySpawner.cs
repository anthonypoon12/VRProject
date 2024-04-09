using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject theEnemy;
    public GameObject theHealth;
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
        while (EnemyCount < 10)
        {
            // Randomize spawn position
            float xPos = Random.Range(minxPos, maxxPos);
            float zPos = Random.Range(minzPos, maxzPos);

            // Instantiate enemy at random position
            // Instantiate(theEnemy, new Vector3(minxPos, 3, minxPos), Quaternion.identity);
            Instantiate(theEnemy, new Vector3(xPos, 100, zPos), Quaternion.identity);

            // Adjust spawn rate
            float spawnRate = Random.Range(0.5f, 1f);
            yield return new WaitForSeconds(spawnRate);

            EnemyCount++;
        }
    }
}