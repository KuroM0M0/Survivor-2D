[System.Serializable] // Damit es im Inspektor sichtbar ist
public class Upgrade
{
    public string Name;           // z.B. "Laufschuhe"
    public string Beschreibung;   // z.B. "Erhöht das Tempo um 10%"
    public float Wert;            // z.B. 1.1f (für 10% mehr)
    public UpgradeTyp Typ;        // Was genau wird verbessert?
}

public enum UpgradeTyp { Speed, Health, Damage, Fähigkeit }