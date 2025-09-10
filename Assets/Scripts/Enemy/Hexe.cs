using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexe : BasisEnemy
{
    public GameObject TrankPrefab;
    GameObject trank;
    int DropChance = 80;
    float WurfInterval = 3f;





    void Start() {
        speed = 1.5f;
        DistanzZumSpieler = 2.5f;
        trank = GameObject.Find("SchadensTrank");
        StartCoroutine(WirfTrank());
        health = 5;
        EnemyType = "Hexe";
        setXP();
    } 



    void Update() {
        Eingefroren();
        Distanz();
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        if(health <= 0) {
                if(DropChance > GameManager.Zufall) {
                    GameObject Drop = Instantiate(DropPrefab, transform.position, Quaternion.identity);
                }

                Destroy(gameObject);
                Highscore.score += 5;
                GameObject Coin = Instantiate(CoinPrefab, transform.position, Quaternion.identity);
            }
    }



    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Schwert")) {
            health -= 2;
        }
        if(other.CompareTag("Bullet")) {
            health--;
        }

        if(other.CompareTag("Wurfmesser")) {
            health -= 2;
        }
    }



    IEnumerator WirfTrank() {
        while(true) {
            yield return new WaitForSeconds(WurfInterval);
            if(distance <= DistanzZumSpieler && !ItemEinfrieren.eingefroren) {
                GameObject trank = Instantiate(TrankPrefab, transform.position, Quaternion.identity);
            }
        }
    }

     protected override float getLocalSpeed() { 
         return 1.5f;
     } 
}