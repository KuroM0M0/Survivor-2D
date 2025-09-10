using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skelett : BasisEnemy
{
    int trefferKugel = 80;
    int trefferSchwert = 90;
    int trefferMesser = 75;
    int trefferWurfmesser = 60;
    int DropCoinChance = 60;
    float wurfInterval = 3f;
    public GameObject bonePrefab;





    void Start() {
        speed = 1;
        DistanzZumSpieler = 2f;
        target = GameObject.Find("Spieler");
        StartCoroutine(WirfKnochen());
        health = 2;
        EnemyType = "Skelett";
        setXP();
    }





    void Update() {
        Eingefroren();
        Distanz();
        
        //Bewegung für Gegner
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        


        if(health <= 0) {
            Destroy(gameObject);
            Highscore.score += 2;

            if(DropCoinChance > GameManager.Zufall) {
                GameObject Coin = Instantiate(CoinPrefab, transform.position, Quaternion.identity);
            }
        }
    }





    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Bullet") && trefferKugel > GameManager.Zufall) {
            health--;
        }

        if(other.CompareTag("Schwert") && trefferSchwert > GameManager.Zufall) {
            health--;
        }

        if(other.CompareTag("Messer") && trefferMesser > GameManager.Zufall) {
            health -= 2;
        }
        if(other.CompareTag("Wurfmesser") && trefferWurfmesser > GameManager.Zufall) {
            health--;
        }
    }





    IEnumerator WirfKnochen() {
        while(true) {
            yield return new WaitForSeconds(wurfInterval);
            if(distance <= 3 && !ItemEinfrieren.eingefroren) {
            GameObject Knochen = Instantiate(bonePrefab, transform.position, Quaternion.identity);
            }
        }
    }

    protected override float getLocalSpeed() {
        return 1;
    }
}