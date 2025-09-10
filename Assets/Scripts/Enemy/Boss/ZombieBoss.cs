using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBoss : BasisEnemy
{

    void Start() {
        health = 50;
        speed = 2.5f;
        EnemyType = "ZombieBoss";
    }


    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Schwert") || other.CompareTag("Bullet")) {
            health--;
        }
    }

    protected override float getLocalSpeed() {
        return 2.5f;
    }

}