using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoZombie : BasisEnemy
{
    public List<GameObject> EnemyPrefab;
    float SpawnRadius = 2;
    float SpawnInterval = 10;
    //public static bool Tot = false;





    void Start() {
        DistanzZumSpieler = 10f;
        ItemDropChance = 50;
        Distanz();
        StartCoroutine(SpawnEnemy());
        target = GameObject.FindGameObjectWithTag("Player");
        player = GameObject.Find("Spieler").transform;
        health = 8;
        maxHealth = 8;
        EnemyType = "DiscoZombie";
    } 





    void Update() {
        Distanz();
        Eingefroren();
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        /*if(health <= 0) {
            Highscore.score += 8;
            //Tot = true;
            DropCoin();
            DropItem();
            Destroy(gameObject);
        }*/
        OnDeath(true, true, 8);
    }





    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Bullet")) {
            health--;
        }
        if(other.CompareTag("Schwert")) {
            health -= 3;
        }
    }





    IEnumerator SpawnEnemy() {
        while(true) {
            yield return new WaitForSeconds(SpawnInterval);
            Vector2 spawnPoint = Random.insideUnitCircle * SpawnRadius;
            int randomIndex = Random.Range(0, EnemyPrefab.Count);
            GameObject RandomEnemyPrefab = EnemyPrefab[randomIndex];
            GameObject Enemy = Instantiate(RandomEnemyPrefab, spawnPoint, Quaternion.identity);
        }
    }

    protected override float getLocalSpeed() {
        return 1.5f;
    }
}