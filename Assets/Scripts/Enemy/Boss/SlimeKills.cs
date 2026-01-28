using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;

public class SlimeKills : MonoBehaviour
{
    public GameObject SlimeBossPrefab;          //Prefab für den Boss
    int kills;                                   //Zahl der getöteten Slimes seit dem letzten Boss
    int allKills;                               //Zahl aller getöteten Slimes
    int Zufall;                                 //Zufallszahl (1-100)
    int SpawnChance = 20;                       //Chance, dass der Boss spawnt
    int spawnDistance = 10;                     //Die Distanz in der der Boss spawnt

    void Update() {
        // TODO Save.MonsterKills.Add("Slimes", allKills);

        //Holt die Zahl der Slimekills
        kills = GameManager.Instance.SlimeKills;  

        //überprüft ob ein Slime gerade getötet wurde
        if(Slime.SlimeNowDead == true) {
            Zufall = GameManager.Instance.GetRandomNumber();
            //Überprüft ob mehr als 100 Slimes tot sind und die Zufallszahl unter 20 ist
            if(kills >= 100 && SpawnChance <= Zufall) {
                GameManager.Instance.SlimeKills = 0;
                SpawnBoss();
                Slime.SlimeNowDead = false;
            }
        }
    }


    public void SpawnBoss() {
        //Ermittelt die Spawnposition
        Vector2 randomSpawnPosition = Random.insideUnitCircle * spawnDistance;
        //Spawnt den Boss
        Instantiate(SlimeBossPrefab, randomSpawnPosition, Quaternion.identity);
    }
}