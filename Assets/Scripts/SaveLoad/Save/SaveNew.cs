using UnityEngine;
using BayatGames.SaveGameFree;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SaveNew : MonoBehaviour {

    [System.Serializable]
    public class SaveData {
        // Hier listest du ALLES auf, was gespeichert werden soll
        public float[] playerPos = new float[2]; // Vector2 ist oft schwer zu serialisieren, float-Arrays sind sicherer
        public int currentLevel;
        public int SlimeKills;
        public int score;
        public int highScore;
        public int wurfmesser;
        public bool hatSchwert;
        public bool hatDash;
        public bool hatWurfmesser;
        public float speed;
        public int ammoDrop;
        public int coinDrop;
        public bool allDrop;
        public float additionalDropChance;
        public int Mehrfachschuss;
        public int coins;
        public int health;
        public float xp;
        public int ammo;
        
        // Auch komplexe Daten wie deine Gegner-Liste passen hier rein
        public Dictionary<string, List<float[]>> spawnedEnemies;
    }

    public class SaveStatData {
        //Shop
        public int earnedCoins;
        public int spentCoins;

        //Kampf
        public int gainedHealth;
        public int damageTaken;

        //Level
        public float gainedXp;
        public int gainedLevel;
        //public int highestLevel;

        //Enemys
        public int killedEnemies;
        public int killedBosses;
        public int killedSlimeBosses;
        public int slimeKills;
        public int kSlimeKills;
        public int zombieKills;
        public int hexenKills;
        public int koboldKills;
        public int baumKills;
        public int discoKills;
        public int skeletonKills;

        //Travel
        public float distanceTraveled;
        public float distanceTraveledByFeet;
        public float distanceTraveledInBoat;
        

        public int ammo;
    }



    

    public static void SaveAll() {
        SaveData data = SaveGame.Exists("SaveGame.dat") ? SaveGame.Load<SaveData>("SaveGame.dat") : new SaveData();

        // 1. Werte, die IMMER gespeichert werden (auch im Shop)
        data.coins = GameManager.Instance.money;
        data.xp = GameManager.Instance.currentXp;
        data.health = BasisPlayer.health; // Wir nehmen den aktuellen Wert aus der Logik
        data.ammo = Schuss.ammo;
        data.wurfmesser = GameManager.Instance.wurfmesser;
        data.score = Highscore.score;
        data.highScore = Highscore.highScore;
        data.SlimeKills = GameManager.Instance.SlimeKills;

        // Upgrades & Stats
        data.speed = BasisPlayer.normalSpeed;
        data.ammoDrop = BasisPlayer.ammoDrop;
        data.coinDrop = BasisPlayer.coinDrop;
        data.allDrop = BasisPlayer.AllDrop;
        data.additionalDropChance = BasisPlayer.AdditionalDropChance;
        data.Mehrfachschuss = BasisPlayer.Mehrfachschuss;
        data.hatDash = BasisPlayer.DashFreigeschaltet;
        data.hatWurfmesser = BasisPlayer.WurfmesserFreigeschaltet;
        data.hatSchwert = BasisPlayer.hatSchwert;

        // 2. Werte, die im Shop NICHT überschrieben werden dürfen
        if (SceneManager.GetActiveScene().name != "ShopScene") {
            data.playerPos = new float[] { Bewegung.PlayerPos.x, Bewegung.PlayerPos.y };
            data.currentLevel = GameManager.Instance.currentLevel;
            data.spawnedEnemies = GetSerializedEnemies();
        }

        SaveGame.Save("SaveGame.dat", data);
        Debug.Log("Speichervorgang abgeschlossen.");
    }


    private static Dictionary<string, List<float[]>> GetSerializedEnemies() {
        var serializedEnemies = new Dictionary<string, List<float[]>>();

        // Sucht ALLE Objekte, die das Skript "BasisEnemy" haben (egal welcher Tag!)
        BasisEnemy[] allEnemies = FindObjectsByType<BasisEnemy>(FindObjectsSortMode.None);

        foreach (BasisEnemy enemy in allEnemies) {
            string type = enemy.EnemyType; // Hier kannst du "Boss" oder "Slime" im Inspektor festlegen
            
            float[] pos = new float[] { 
                enemy.transform.position.x, 
                enemy.transform.position.y 
            };

            if (!serializedEnemies.ContainsKey(type)) {
                serializedEnemies[type] = new List<float[]>();
            }
            serializedEnemies[type].Add(pos);
        }
        return serializedEnemies;
    }

    public void SaveStats() {
        SaveStatData data = SaveGame.Exists("Stats.dat") ? SaveGame.Load<SaveStatData>("Stats.dat") : new SaveStatData();

        
    }
}