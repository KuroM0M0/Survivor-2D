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
    int DropChance = 40;                            //Chance Item DropPrefab zu droppen
    float SlimeDauer = 4;                           //Wartezeit für SlimeNowDead
    public static bool SlimeOnPlayer = false;       //Wenn Slime den Spieler berührt, ist Slime langsamer
    public static bool SlimeNowDead = false;        //Wenn der Slime Tot ist wird auf true gesetzt. Ist für den SlimeBoss
    public static int SlimeKills;                   //Wie viele Slimes Tot sind. Ist für SlimeBoss
    


    void Start() {
        target = GameObject.Find("Spieler");
        speed = 1;
        health = 5;
        EnemyType = "Slime";
        setXP();
    }

    
    void Update() {
        Eingefroren();
        SlimeKills = Load.LoadSlimeKills();

        //Generiert Zufallszahl
        SplitZahl = Random.Range(1, 5);
        //Bewegung
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        //Spawnt kleine Slimes wenn stirbt
        if(health <= 0) {
            if(GameManager.Zufall <= SplitChance) {
                if(SplitZahl == 1) {
                    Instantiate(kSlimePrefab, transform.position, Quaternion.identity);
                } else if(SplitZahl == 2) {
                    Instantiate(kSlimePrefab, transform.position, Quaternion.identity);
                    Instantiate(kSlimePrefab, transform.position, Quaternion.identity);
                } else if(SplitZahl == 3) {
                    Instantiate(kSlimePrefab, transform.position, Quaternion.identity);
                    Instantiate(kSlimePrefab, transform.position, Quaternion.identity);
                    Instantiate(kSlimePrefab, transform.position, Quaternion.identity);
                } else if(SplitZahl == 4) {
                    Instantiate(kSlimePrefab, transform.position, Quaternion.identity);
                    Instantiate(kSlimePrefab, transform.position, Quaternion.identity);
                    Instantiate(kSlimePrefab, transform.position, Quaternion.identity);
                    Instantiate(kSlimePrefab, transform.position, Quaternion.identity);
                } else if(SplitZahl == 5) {
                    Instantiate(kSlimePrefab, transform.position, Quaternion.identity);
                    Instantiate(kSlimePrefab, transform.position, Quaternion.identity);
                    Instantiate(kSlimePrefab, transform.position, Quaternion.identity);
                    Instantiate(kSlimePrefab, transform.position, Quaternion.identity);
                    Instantiate(kSlimePrefab, transform.position, Quaternion.identity);
                }
                
            }
            if(GameManager.Zufall >= DropChance) {
                Instantiate(DropPrefab, transform.position, Quaternion.identity);
            }
            
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