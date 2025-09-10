using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkelettBoss : MonoBehaviour
{
    int health = 150;
    float localSpeed;
    public string EnemyType = "SkelettBoss";

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Schwert") || other.CompareTag("Bullet")) {
            health--;
        }
    }

   /* void Start() {
        localSpeed = EnemySpeed.speed2;
    }

    void Update() {
        if(ItemEinfrieren.bossEingefroren == true) {
            localSpeed = 0;
        } else {
            localSpeed = EnemySpeed.speed2;
        }
    } */
}