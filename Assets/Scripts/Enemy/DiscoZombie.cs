using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoZombie : BasisEnemy
{
    GameObject Player;
    Transform PlayerTr;
    public List<GameObject> EnemyPrefab;
    float SpawnRadius = 2;
    float SpawnInterval = 10;
    public static bool Tot = false;
    int DropChance = 50;





    void Start() {
        DistanzZumSpieler = 10;
        Distanz();
        StartCoroutine(SpawnEnemy());
        target = GameObject.FindGameObjectWithTag("Player");
        Player = GameObject.Find("Spieler");
        PlayerTr = Player.GetComponent<Transform>();
        health = 8;
        EnemyType = "DiscoZombie";
        setXP();
    } 





    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        Distanz();
        Eingefroren();

        if(health <= 0) {
                Highscore.score += 8;
                Tot = true;
                GameObject Coin = Instantiate(CoinPrefab, transform.position, Quaternion.identity);
                
               if(DropChance >= GameManager.Zufall) {
                 GameObject Drop = Instantiate(DropPrefab, transform.position, Quaternion.identity);
               }
               Destroy(gameObject);
            }
    }





    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Bullet")) {
            health--;
        }
        if(other.CompareTag("Schwert")) {
            health -= 3;
        }

        if(other.CompareTag("Messer")) {
            health-= 2;
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