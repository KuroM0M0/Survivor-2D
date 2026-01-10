using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class KSlime : BasisEnemy
{
    void Start() {
        target = GameObject.Find("Spieler");
        ItemDropChance = 20;
        CoinDropChance = 35;
        speed = 1;
        health = 1;
        maxHealth = 1;
        EnemyType = "KSlime";
    }

    void Update() {
        Eingefroren();
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        OnDeath(true, true, 0);
    }


     void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Bullet")) {
            health--;
        }
        if(other.CompareTag("Wurfmesser")) {
            health--;
        }
        if(other.CompareTag("Schwert")) {
            health--;
        }
     }

    protected override float getLocalSpeed() {
        return 1;
    }
}