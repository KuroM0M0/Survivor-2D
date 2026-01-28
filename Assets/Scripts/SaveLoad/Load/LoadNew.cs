using UnityEngine;
using BayatGames.SaveGameFree;

public class LoadNew : MonoBehaviour
{
    public static bool Check(string fileName) {
       return SaveGame.Exists(fileName);
    }

    public static void LoadAll() {
        if(Check("SaveGame.dat")) {
            SaveNew.SaveData data = SaveGame.Load<SaveNew.SaveData>("SaveGame.dat");

            // --- 1. Verteilung an den GameManager (Source of Truth) ---
            GameManager.Instance.money = data.coins;
            GameManager.Instance.currentXp = data.xp;
            GameManager.Instance.currentLevel = data.currentLevel;
            GameManager.Instance.health = data.health;
            GameManager.Instance.ammo = data.ammo;
            GameManager.Instance.wurfmesser = data.wurfmesser;
            GameManager.Instance.SlimeKills = data.SlimeKills;
            GameManager.Instance.score = data.score;
            GameManager.Instance.highScore = data.highScore;
            
            // Stats & Upgrades
            GameManager.Instance.speed = data.speed;
            GameManager.Instance.ammoDrop = data.ammoDrop;
            GameManager.Instance.coinDrop = data.coinDrop;
            GameManager.Instance.allDrop = data.allDrop;
            GameManager.Instance.additionalDropChance = data.additionalDropChance;
            GameManager.Instance.mehrfachschuss = data.Mehrfachschuss;
            GameManager.Instance.hatDash = data.hatDash;
            GameManager.Instance.hatWurfmesser = data.hatWurfmesser;
            GameManager.Instance.hatSchwert = data.hatSchwert;

            // --- 2. Verteilung an die statischen Variablen (für die Logik) ---
            // Position
            Bewegung.PlayerPos = new Vector2(data.playerPos[0], data.playerPos[1]);

            // BasisPlayer Stats
            BasisPlayer.health = data.health;
            BasisPlayer.normalSpeed = data.speed;
            BasisPlayer.speed = data.speed;
            BasisPlayer.ammoDrop = data.ammoDrop;
            BasisPlayer.coinDrop = data.coinDrop;
            BasisPlayer.AllDrop = data.allDrop;
            BasisPlayer.AdditionalDropChance = data.additionalDropChance;
            BasisPlayer.Mehrfachschuss = data.Mehrfachschuss;
            BasisPlayer.DashFreigeschaltet = data.hatDash;
            BasisPlayer.WurfmesserFreigeschaltet = data.hatWurfmesser;
            BasisPlayer.hatSchwert = data.hatSchwert;

            // Sonstige
            Schuss.ammo = data.ammo;
            Highscore.highScore = data.highScore;
            Highscore.score = data.score;
            Menü.LebenFürButton = data.health;

            Debug.Log("Spielstand erfolgreich in alle Systeme geladen!");
        }
    }
}