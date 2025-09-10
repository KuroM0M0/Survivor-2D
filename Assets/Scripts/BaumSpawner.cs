using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaumSpawner : MonoBehaviour
{
    public GameObject BaumPrefab;
    public int BaumAnzahl;
    public Vector2 spawnArea = new Vector2(50, 50);


    void Start() {
        for (int i = 0; i < BaumAnzahl; i++) {
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnArea.x / 2, spawnArea.x / 2), Random.Range(-spawnArea.y / 2, spawnArea.y / 2), 0);
            Instantiate(BaumPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
