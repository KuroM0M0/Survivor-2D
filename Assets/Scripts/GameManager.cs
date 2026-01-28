using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
    // --- SINGLETON PATTERN ---
    // Das erlaubt den Zugriff von überall mit: GameManager.Instance
    public static GameManager Instance { get; private set; }


    [Header("Spieler Status & Fortschritt")]
    public int health;
    public int ammo;
    public int money;
    public int wurfmesser;
    public int SlimeKills;
    public int score;
    public int highScore;

    [Header("Level System")]
    public int currentLevel;
    public float currentXp;
    public List<int> xpThresholds = new List<int> { 50, 100, 200, 500, 1000 };
    [HideInInspector]
    public Levelup levelupMenu;

    [Header("Upgrades & Stats (Sync mit BasisPlayer)")]
    public float speed;
    public float normalSpeed;
    public int ammoDrop;
    public int coinDrop;
    public float additionalDropChance;
    public bool allDrop;
    public int mehrfachschuss;
    public bool hatDash;
    public bool hatWurfmesser;
    public bool hatSchwert;
    public float unverwundbarTimer;




    void Awake() {
        // Sicherstellen, dass es nur einen GameManager gibt
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }



    // Deine bestehende Zufallsfunktion (jetzt nicht mehr static nötig, da Instance genutzt wird)
    public int GetRandomNumber() {
        return Random.Range(0, 100);
    }




    // --- LEVEL LOGIK ---
    public void AddXP(float amount) {
        currentXp += amount;
        StatManager.Instance.AddStat("gainedXp", amount);
        Debug.Log("XP erhalten: " + amount + " | Gesamt: " + currentXp);

        CheckLevelUp();
    }

    public void RemoveXP(float amount) {
        currentXp -= amount;
        Debug.Log("XP verloren: " + amount + " | Gesamt: " + currentXp);
    }



    private void CheckLevelUp() {
        // Prüfen, ob wir noch ein Level in der Liste haben
        if (currentLevel < xpThresholds.Count) {
            if (currentXp >= xpThresholds[currentLevel]) {
                currentXp -= xpThresholds[currentLevel]; // Rest-XP mitnehmen
                currentLevel++;
                
                StatManager.Instance.AddStat("gainedLevel", 1);
                Debug.Log("LEVEL UP! Neues Level: " + currentLevel);
                //Save.SaveLevel(); 
                if (levelupMenu != null) {
                    levelupMenu.ShowModal();
                }
                
                // Falls man direkt genug XP für 2 Level bekommen hat (Rekursion)
                CheckLevelUp(); 
            }
        }
    }

    void OnApplicationQuit() {
        SaveNew.SaveAll(); 
    }
}