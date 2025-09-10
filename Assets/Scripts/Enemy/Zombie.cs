using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : BasisEnemy {
    int DropChance = 30;
    int DropCoinChance = 70;
    public static bool Tot = false;
    public static int statKill;
    


    void Start() {
        target = GameObject.Find("Spieler");
        speed = 1.5f;
        health = 1;
        EnemyType = "Zombie";
        setXP();
    }

    void Update() {
        Eingefroren();
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        if(health <= 0) {

            if(DropChance > GameManager.Zufall) {
                GameObject Drop = Instantiate(DropPrefab, transform.position, Quaternion.identity);
            }

            if(DropCoinChance > GameManager.Zufall) {
                GameObject Coin = Instantiate(CoinPrefab, transform.position, Quaternion.identity);
            } 

            Destroy(gameObject);
            Highscore.score++;
            Tot = true;
            statKill++;
            }
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