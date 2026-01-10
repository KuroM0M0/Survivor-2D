using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
    // --- SINGLETON PATTERN ---
    // Das erlaubt den Zugriff von überall mit: GameManager.Instance
    public static GameManager Instance { get; private set; }



    [Header("Level System")]
    public int currentLevel = 0;
    public float currentXp = 0;
    // Die XP, die man für das jeweilige Level braucht
    public List<int> xpThresholds = new List<int> { 50, 100, 200, 500, 1000 };




    void Awake() {
        // Sicherstellen, dass es nur einen GameManager gibt
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: Bleibt beim Szenenwechsel erhalten
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
                
                Debug.Log("LEVEL UP! Neues Level: " + currentLevel);
                
                // Hier kannst du das Speichern aufrufen
                Save.SaveLevel(); 
                
                // Falls man direkt genug XP für 2 Level bekommen hat (Rekursion)
                CheckLevelUp(); 
            }
        }
    }
}