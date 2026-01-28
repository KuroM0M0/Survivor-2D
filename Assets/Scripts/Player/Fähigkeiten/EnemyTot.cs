using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTot : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject enemy in enemies) {
                Destroy(enemy);
            }
            Destroy(gameObject);
        }
    }
}
