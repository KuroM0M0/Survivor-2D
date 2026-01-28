using UnityEngine;

[System.Serializable] // Damit es im Inspektor sichtbar ist
public class Upgrade {
    public string Name;           // z.B. "Laufschuhe"
    public string Beschreibung;   // z.B. "Erhöht das Tempo um 10%"
    public float Wert;            // z.B. 0.1f (für 10% mehr)
    public Sprite Image;
    public UpgradeTyp Typ;        // Was genau wird verbessert?
}

public enum UpgradeTyp { Speed, Health, Damage, UnverwundbarTimer, MehrSchuss, Dash, MehrCoins, DashFrei }