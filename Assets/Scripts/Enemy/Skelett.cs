using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skelett : BasisEnemy
{
    int trefferKugel = 80;
    int trefferSchwert = 90;
    int trefferMesser = 75;
    int trefferWurfmesser = 60;
    float wurfInterval = 3f;
    public GameObject bonePrefab;





    void Start() {
        CoinDropChance = 60;
        speed = 1;
        DistanzZumSpieler = 2f;
        target = GameObject.Find("Spieler");
        StartCoroutine(WirfKnochen());
        health = 2;
        maxHealth = 2;
        EnemyType = "Skelett";
    }





    void Update() {
        Eingefroren();
        Distanz();
        
        //Bewegung für Gegner
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        OnDeath(true, false, 2);
    }





    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Bullet") && trefferKugel > GameManager.Instance.GetRandomNumber()) {
            health--;
        }

        if(other.CompareTag("Schwert") && trefferSchwert > GameManager.Instance.GetRandomNumber()) {
            health--;
        }

        if(other.CompareTag("Messer") && trefferMesser > GameManager.Instance.GetRandomNumber()) {
            health -= 2;
        }
        if(other.CompareTag("Wurfmesser") && trefferWurfmesser > GameManager.Instance.GetRandomNumber()) {
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