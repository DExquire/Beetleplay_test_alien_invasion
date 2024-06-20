using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int maxEnemies = 10;
    public float spawnInterval = 3f;
    public float spawnRadius = 2;

    private GameObject[] enemyPool;

    void Start()
    {
        enemyPool = new GameObject[maxEnemies];

        for (int i = 0; i < maxEnemies; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity);
            enemy.SetActive(false);
            enemyPool[i] = enemy;
            Vector3 randomPosition = transform.position + Random.insideUnitSphere * spawnRadius;
            randomPosition.y = 0f;
            enemyPool[i].transform.position = randomPosition;
            enemyPool[i].GetComponent<Collider>().isTrigger = false;
            enemyPool[i].gameObject.SetActive(true);
        }

        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            for (int i = 0; i < maxEnemies; i++)
            {
                if (!enemyPool[i].activeInHierarchy)
                {
                    Vector3 randomPosition = transform.position + Random.insideUnitSphere * spawnRadius;
                    randomPosition.y = 0f;

                    enemyPool[i].transform.position = randomPosition;
                    enemyPool[i].SetActive(true);

                    break;
                }
            }
        }
    }
}
