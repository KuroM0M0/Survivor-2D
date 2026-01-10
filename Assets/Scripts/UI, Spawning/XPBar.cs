using UnityEngine;
using UnityEngine.UI; // Wichtig für den Zugriff auf den Slider

public class XpBar : MonoBehaviour
{
    private Slider slider;

    void Awake() {
        slider = GetComponent<Slider>();
    }

    void Update() {
        UpdateXpDisplay();
    }

    void UpdateXpDisplay() {
        // 1. Wir holen uns die Daten aus dem GameManager
        float currentXp = GameManager.Instance.currentXp;
        int currentLevel = GameManager.Instance.currentLevel;
        
        // Sicherheit: Prüfen, ob wir noch in der Liste der XP-Grenzen sind
        if (currentLevel < GameManager.Instance.xpThresholds.Count) {
            float targetXp = GameManager.Instance.xpThresholds[currentLevel];

            // 2. Den Wert für den Slider berechnen (zwischen 0 und 1)
            // Beispiel: 50 XP von 100 benötigten = 0.5f
            float progress = currentXp / targetXp;

            // 3. Den Balken füllen
            //slider.value = progress;
            slider.value = Mathf.Lerp(slider.value, progress, Time.deltaTime * 5f);
        }
        else {
            // Max Level erreicht: Balken voll lassen
            slider.value = 1f;
        }
    }
}