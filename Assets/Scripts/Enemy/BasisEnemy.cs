using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasisEnemy : MonoBehaviour
{
    public string EnemyType; //Wird nur zum Speichern verwendet
    public int health;
    protected int maxHealth;
    static protected GameObject target;
    protected float speed;
    public GameObject CoinPrefab;
    public GameObject DropPrefab;
    protected float distance;
    protected float DistanzZumSpieler;
    protected Transform player;
    protected int ItemDropChance;
    protected int CoinDropChance = 100;


    protected void Distanz() {
        if(target && player) {
            distance = Vector2.Distance(player.position, transform.position);
            if(distance <= DistanzZumSpieler || ItemEinfrieren.eingefroren) {
                speed = 0;
            } else {
                speed = getLocalSpeed();
            }
        }
    }

    protected abstract float getLocalSpeed();

    protected void Eingefroren() {
        if(ItemEinfrieren.eingefroren) {
            speed = 0;
        } else {
            speed = getLocalSpeed();
        }
    }

    protected void OnDeath(bool Coin, bool Item, int score) {
        if(health <= 0) {
            //Level
            float xp = maxHealth / 2;
            GameManager.Instance.AddXP(xp);

            //Drops
            if(Coin) {
                DropCoin();
            }
            if(Item) {
                DropItem();
            }

            //Highscore
            Highscore.score += score;

            //Delete Enemy
            Destroy(gameObject);
        }
    }

    protected void DropCoin() {
        if(CoinDropChance >= GameManager.Instance.GetRandomNumber()) {
            Instantiate(CoinPrefab, transform.position, Quaternion.identity);
        }
    }

    protected void DropItem() {
        float range = 0.5f;
        Vector3 randomOffset = new Vector3(
            Random.Range(-range, range), 
            Random.Range(-range, range), 
            0f
        );
        if(ItemDropChance >= GameManager.Instance.GetRandomNumber()) {
            Vector3 enemyPosition = transform.position;
            Instantiate(DropPrefab, enemyPosition + randomOffset, Quaternion.identity);
        }
    }
}