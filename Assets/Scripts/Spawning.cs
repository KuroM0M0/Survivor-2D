using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{

    public List<GameObject> EnemyPrefabs;
    public float spawnRadius = 30f;
    public float spawnInterval = 2.5f;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy() {
        while(true) {
            yield return new WaitForSeconds(spawnInterval);
            Vector2 spawnPoint = Random.insideUnitCircle * spawnRadius;
            int randomIndex = Random.Range(0, EnemyPrefabs.Count);
            GameObject RandomEnemyPrefab = EnemyPrefabs[randomIndex];
            GameObject Enemy = Instantiate(RandomEnemyPrefab, spawnPoint, Quaternion.identity);
        }
    }

}
