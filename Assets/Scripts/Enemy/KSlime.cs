using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class KSlime : BasisEnemy
{
    int DropChance = 20;
    int CoinChance = 35;


    void Start() {
        target = GameObject.Find("Spieler");
        speed = 1;
        health = 1;
        EnemyType = "KSlime";
        setXP();
    }

    void Update() {
        Eingefroren();
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        

        if(health <= 0) {
            if(GameManager.Zufall <= DropChance) {
            Instantiate(DropPrefab, transform.position, Quaternion.identity);
        }
        if(GameManager.Zufall <= CoinChance) {
            Instantiate(CoinPrefab, transform.position, Quaternion.identity);
        }
            GameManager.exp += xp;
            Destroy(gameObject);
        }
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