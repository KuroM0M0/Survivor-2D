using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kobold : BasisEnemy {
    GameObject Spieler;
    public static bool Tot = false;


    void Start() {
        Spieler = GameObject.FindGameObjectWithTag("Player");
        speed = 2.5f;
        health = 1;
        EnemyType = "Kobold";
    }

    void Update() {
        Eingefroren();
        transform.position = Vector2.MoveTowards(transform.position, Spieler.transform.position, speed * Time.deltaTime);
        if(health <= 0) {
            Destroy(gameObject);
            Tot = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Bullet")) {
            health--;
        }
        if(other.CompareTag("Schwert")) {
            health--;
        }

        if(other.CompareTag("Messer")) {
            health -= 2;
        }
    }

    protected override float getLocalSpeed() {
        return 2.5f;
    }
}