using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using BayatGames.SaveGameFree;

public class Levelup : MonoBehaviour
{
    public List<Upgrade> alleUpgrades; // Liste aller Upgrades (im Inspektor füllen)
    public TMP_Text[] buttonTexte;     // Ziehe hier die 3 Text-Komponenten deiner Buttons rein
    
    private List<Upgrade> aktuelleAuswahl = new List<Upgrade>();
    


    public void ShowModal() {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
        GeneriereOptionen();
    }

    public void HideModal() {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    void GeneriereOptionen() {
        aktuelleAuswahl.Clear();
        // Wir kopieren die Liste, um Originaldaten nicht zu verändern
        List<Upgrade> kopieListe = new List<Upgrade>(alleUpgrades);

        for(int i = 0; i < 3; i++) {
            if(kopieListe.Count > 0) {
                int index = Random.Range(0, kopieListe.Count);
                Upgrade gewählt = kopieListe[index];
                
                aktuelleAuswahl.Add(gewählt);
                buttonTexte[i].text = gewählt.Name + "\n" + gewählt.Beschreibung;
                
                // Wichtig: Aus der Kopie löschen, damit kein Upgrade doppelt erscheint
                kopieListe.RemoveAt(index);
            }
        }
    }

    public void WähleOption(int index) {
        Upgrade gewähltesUpgrade = aktuelleAuswahl[index];
        Anwenden(gewähltesUpgrade);
        HideModal();
    }

    void Anwenden(Upgrade u) {
        // Hier passiert die Magie: Je nach Typ ändern wir die Stats
        switch (u.Typ) {
            case UpgradeTyp.Speed:
                // Beispiel: Spieler.speed *= u.Wert;
                Debug.Log("Speed erhöht!");
                break;
            case UpgradeTyp.Health:
                Debug.Log("Leben erhöht!");
                break;
            case UpgradeTyp.Damage:
                Debug.Log("Schaden erhöht!");
                break;
        }
    }
}