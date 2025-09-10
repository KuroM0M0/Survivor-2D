using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBoss : BasisEnemy {
    int DropChance = 40;
    int TrefferChance = 25;
    public GameObject SlimePrefab;


    void Start() {
        target = GameObject.Find("Spieler");
        speed = 1.5f;
        health = 50;
        EnemyType = "SlimeBoss";
    }

    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        if(health <= 0) {
            if(DropChance > GameManager.Zufall) {
                Instantiate(DropPrefab, transform.position, Quaternion.identity);
                
            }
            GameManager.exp += 20;
            Save.SaveExp();
            Coin.money += 15;
            Save.SaveCoin();
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Schwert")) {
            health -= 3;
        }
        if(other.CompareTag("Bullet")) {
            if(TrefferChance >= GameManager.Zufall) {
                health -= 8;
            }
        }
        if(other.CompareTag("Wurfmesser")) {
            health--;
        }
    }

    protected override float getLocalSpeed()
    {
        return 1.5f;
    }
}