using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;

public class Slime : BasisEnemy
{
    public GameObject kSlimePrefab;                 //Prefab für kleinen Slime
    public GameObject SlimeBossPrefab;              //Prefab für Slime Boss
    int SplitChance = 80;                           //Chance das der Slime sich in kleine Slimes aufteilt
    int SplitZahl;                                  //Zufallszahl die angibt, in wie viele kleine Slimes aufgeteilt wird (1-5)
    float SlimeDauer = 4;                           //Wartezeit für SlimeNowDead
    public static bool SlimeOnPlayer = false;       //Wenn Slime den Spieler berührt, ist Slime langsamer
    public static bool SlimeNowDead = false;        //Wenn der Slime Tot ist wird auf true gesetzt. Ist für den SlimeBoss
    public static int SlimeKills;                   //Wie viele Slimes Tot sind. Ist für SlimeBoss
    


    void Start() {
        ItemDropChance = 40;
        target = GameObject.Find("Spieler");
        speed = 1;
        health = 5;
        maxHealth = 5;
        EnemyType = "Slime";
    }

    
    void Update() {
        Eingefroren();
        SlimeKills = Load.LoadSlimeKills();
        
        //Bewegung
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        //Spawnt kleine Slimes wenn stirbt
        if(health <= 0) {
            //Generiert Zufallszahl
            SplitZahl = Random.Range(1, 5);
            if(GameManager.Instance.GetRandomNumber() <= SplitChance) {
                for(int i = 0; i < SplitZahl; i++) {
                    Instantiate(kSlimePrefab, transform.position, Quaternion.identity);
                }
            }

            DropItem();
            SlimeKills++;
            Highscore.score += 2;
            Save.SaveSlimeKills();
  
            StartCoroutine(WaitForSlimeDead());
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Bullet")) {
            health--;
        }
        if(other.CompareTag("Wurfmesser")) {
            health--;
        } 

        if(other.CompareTag("Player")) {
            Bewegung.speed = 1;
            SlimeOnPlayer = true;
            StartCoroutine(PlayerAttachet());
        }
    }


    void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            SlimeOnPlayer = false;
        }
    }

    IEnumerator PlayerAttachet() {
        speed = 2;
        yield return new WaitForSeconds(SlimeDauer);
        speed = 1;
        SlimeOnPlayer = false;
    }

    IEnumerator WaitForSlimeDead() {
        SlimeNowDead = true;
        yield return new WaitForSeconds(2);
        SlimeNowDead = false;
    }

    protected override float getLocalSpeed()
    {
        return 1;
    }
}