using UnityEngine;
using System.Collections.Generic;

public class StatManager : MonoBehaviour
{
    public static StatManager Instance { get; private set; }

    public Dictionary<string, float> enemyStats = new Dictionary<string, float>();

    public void AddStat(string name, float amount) {
        if(enemyStats.ContainsKey(name)) {
            enemyStats[name] += amount;
        } else {
            // Falls der Gegner noch nicht im Wörterbuch ist, neu anlegen
            enemyStats[name] = amount;
        }
    }

    void Awake() {
        // Sicherstellen, dass es nur einen GameManager gibt
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
}
