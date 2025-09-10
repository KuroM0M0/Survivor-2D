using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;
using UnityEngine.Analytics;

public class Save : MonoBehaviour {

    public static void SaveAll() {
        SavePlayerPos();
        SaveLevel();
        SaveSlimeKills();
        //SaveScore();
        SaveCoin();
        SaveLeben();
        SaveExp();
        SaveWurfmesser();
        SaveAmmo();
        SaveSchwert();
        SaveSpawnedEnemys();
        SaveDash();
        SaveDashFreigeschaltet();
        SaveWurfmesserFreigeschaltet();
        SaveSpeed();
        SaveMuniDrop();
        SaveGeldDrop();
        SaveAllDrop();
        SaveAdditionalDropChance();
        SaveMehrfachschuss();
    }

    public static void SavePlayerPos() {
       SaveGame.Save("PlayerPos", Bewegung.PlayerPos);
    }

    public static void SaveLevel() {
        SaveGame.Save("Level", Levelup.Level);
    } 

    public static void SaveSlimeKills() {
        SaveGame.Save("SlimeKills", Slime.SlimeKills);
    }

    public static void SaveScore() {
        SaveGame.Save("Highscore", Highscore.score);
    }

    public static void SaveCoin() {
        SaveGame.Save("Coin", Coin.money);
    }

    public static void SaveLeben() {
        SaveGame.Save("Leben", Leben.health);
    }

    public static void SaveExp() {
        SaveGame.Save("Exp", GameManager.exp);
    }

    public static void SaveWurfmesser() {
        SaveGame.Save("Wurfmesser", Wurfmesser.wurfmesserAnzahl);
    }

    public static void SaveAmmo() {
        SaveGame.Save("Ammo", Schuss.ammo);
    }

    public static void SaveSchwert() {
        //SaveGame.Save("Schwert", Inventar.HatSchwert);
    }

    public static void SaveDash() {
        SaveGame.Save("Dash", Dash.DashZahl);
    }

    public static void SaveDashFreigeschaltet() {
        SaveGame.Save("DashFreigeschaltet", LevelUpAuswahl.DashFreigeschaltet);
    }

    public static void SaveWurfmesserFreigeschaltet() {
        SaveGame.Save("WurfmesserFreigeschaltet", LevelUpAuswahl.WurfmesserFreigeschaltet);
    }

    public static void SaveSpeed() {
        SaveGame.Save("Speed", BasisPlayer.speed);
    }

    public static void SaveMuniDrop() {
        SaveGame.Save("MuniDrop", BasisPlayer.MuniDrop);
    }

    public static void SaveGeldDrop() {
        SaveGame.Save("GeldDrop", BasisPlayer.GeldDrop);
    }

    public static void SaveAllDrop() {
        SaveGame.Save("AllDrop", BasisPlayer.AllDrop);
    }

    public static void SaveAdditionalDropChance() {
        SaveGame.Save("AdditionalDropChance", BasisPlayer.AdditionalDropChance);
    }

    public static void SaveMehrfachschuss() {
        SaveGame.Save("Mehrfachschuss", BasisPlayer.Mehrfachschuss);
    }

    public static Dictionary<string, int> Stats = new Dictionary<string, int>();

    public static void SaveStats() {
        SaveGame.Save("Stats", Stats);
    }

    public static void SaveSpawnedEnemys() {
        Dictionary<string, List<Vector2>> spawnedEnemys = new Dictionary<string, List<Vector2>>();

        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")) {
            BasisEnemy enemyComponent = enemy.GetComponent<BasisEnemy>(); 
            if(enemyComponent != null) {
                string enemyType = enemyComponent.EnemyType;
                Vector2 position = enemy.transform.position;

            if (!spawnedEnemys.ContainsKey(enemyType)) {
                spawnedEnemys[enemyType] = new List<Vector2>();
            }
            spawnedEnemys[enemyType].Add(position);
            }
        }

        SaveGame.Save("SpawnedEnemys", spawnedEnemys);
    }
}