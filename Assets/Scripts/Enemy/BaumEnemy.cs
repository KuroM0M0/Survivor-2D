using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaumEnemy : BasisEnemy
{
    GameObject Player;
    public Sprite ChangeSprite;
    public float ChangeDistance = 10f;
    //public static bool Tot = false;
    public SpriteRenderer SpriteRenderer;


    public void Start() {
        Player = GameObject.Find("Spieler");
        health = 6;
        maxHealth = 6;
        EnemyType = "Baum";
    }

    public void Update() {
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        if(distance <= ChangeDistance) {
            SpriteRenderer.sprite = ChangeSprite;
        }
        
        OnDeath(false, false, 2);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Bullet")) {
            health--;
        }
        if(other.CompareTag("Schwert")) {
            health--;
        }
    }

    protected override float getLocalSpeed()
    {
        throw new System.NotImplementedException();
    }
}