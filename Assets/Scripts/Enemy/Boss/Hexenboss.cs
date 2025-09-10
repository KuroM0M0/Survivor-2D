using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexenBoss : MonoBehaviour
{
    int health = 100;
    float localSpeed;
    float localBesenSpeed; //speed auf Besen 
    public string EnemyType = "HexenBoss";

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Schwert") || other.CompareTag("Bullet")) {
            health--;
        }
    }

   /* void Start() {
        localSpeed = EnemySpeed.speed2;
        localBesenSpeed = EnemySpeed.speed35;
    }

    void Update() {
        if(ItemEinfrieren.bossEingefroren == true) {
            localSpeed = 0;
            localBesenSpeed = 0.2f;
        } else {
            localSpeed = EnemySpeed.speed2;
            localBesenSpeed = EnemySpeed.speed35;
        }
    } */
}