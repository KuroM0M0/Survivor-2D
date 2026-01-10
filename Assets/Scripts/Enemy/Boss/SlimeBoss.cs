using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBoss : BasisEnemy {
    int TrefferChance = 25;
    public GameObject SlimePrefab;


    void Start() {
        ItemDropChance = 40;
        target = GameObject.Find("Spieler");
        speed = 1.5f;
        health = 50;
        EnemyType = "SlimeBoss";
    }

    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        if(health <= 0) {
            DropItem();
            GameManager.Instance.AddXP(20);
            Save.SaveXP();
            BasisShop.money += 15;
            Save.SaveCoin();
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Schwert")) {
            health -= 2;
        }
        if(other.CompareTag("Bullet")) {
            if(TrefferChance >= GameManager.Instance.GetRandomNumber()) {
                health -= 5;
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