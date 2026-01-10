using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : BasisEnemy {
    //public static bool Tot = false;
    public static int statKill;
    


    void Start() {
        CoinDropChance = 70;
        ItemDropChance = 30;
        target = GameObject.Find("Spieler");
        speed = 1.5f;
        health = 1;
        maxHealth = 1;
        EnemyType = "Zombie";
    }

    void Update() {
        Eingefroren();
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        if(health <= 0) {

            //DropCoin();
            //DropItem();

            //Destroy(gameObject);
            //Highscore.score++;
            //Tot = true;
            statKill++;
            }
            OnDeath(true, true, 1);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Schwert")) {
            health--;
        }
        if(other.CompareTag("Bullet")) {
            health--;
        }
        if(other.CompareTag("Wurfmesser")) {
            health--;
        }
    }

    protected override float getLocalSpeed() {
        return 1.5f;
    } 
}