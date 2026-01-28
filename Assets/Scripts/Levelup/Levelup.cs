using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using BayatGames.SaveGameFree;

public class Levelup : MonoBehaviour
{
    public List<Upgrade> alleUpgrades;  // Liste aller Upgrades (im Inspektor füllen)
    public TMP_Text[] buttonTexte;      //Text der Buttons (Beschreibung, Name)
    public Image[] buttonIcons;         //Icons der Buttons
    private List<Upgrade> aktuelleAuswahl = new List<Upgrade>();
    public List<GameObject> Auswahlfelder = new List<GameObject>();
    
    void Awake() {
        GameManager.Instance.levelupMenu = this;
    }

    public void ShowModal() {
        for(int i = 0; i < 3; i++) {
            Auswahlfelder[i].SetActive(true);
        }
        Time.timeScale = 0f;
        GeneriereOptionen();
    }

    public void HideModal() {
        for(int i = 0; i < 3; i++) {
            Auswahlfelder[i].SetActive(false);
        }
        Time.timeScale = 1f;
    }

    void GeneriereOptionen() {
        aktuelleAuswahl.Clear();
        // Wir kopieren die Liste, um Originaldaten nicht zu verändern
        List<Upgrade> kopieListe = new List<Upgrade>(alleUpgrades);

        //Entfernt Upgrades aus der Liste
        if(BasisPlayer.health >= 3) {
            kopieListe.Remove(kopieListe.Find(upgrade => upgrade.Typ == UpgradeTyp.Health));
        }
        if(BasisPlayer.DashFreigeschaltet) {
            kopieListe.Remove(kopieListe.Find(upgrade => upgrade.Typ == UpgradeTyp.DashFrei));
        }
        kopieListe.Remove(kopieListe.Find(upgrade => upgrade.Typ == UpgradeTyp.MehrSchuss));

        for(int i = 0; i < 3; i++) {
            if(kopieListe.Count > 0) {
                int index = Random.Range(0, kopieListe.Count);
                Upgrade gewählt = kopieListe[index];
                
                aktuelleAuswahl.Add(gewählt);
                buttonTexte[i].text = gewählt.Name + "\n" + gewählt.Beschreibung;

                if(gewählt.Image != null) {
                    buttonIcons[i].sprite = gewählt.Image;     // Das neue Bild zuweisen
                    buttonIcons[i].enabled = true;             // Bild sichtbar machen
                    buttonIcons[i].preserveAspect = true;      // Verhindert Verzerren
                }
                else {
                    // Falls kein Bild da ist, machen wir das Image-Objekt unsichtbar,
                    // damit kein weißes Viereck angezeigt wird.
                    buttonIcons[i].enabled = false; 
                }
                
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
                Debug.Log("Speed erhöht!");
                BasisPlayer.speed += u.Wert;
                BasisPlayer.normalSpeed += u.Wert;
                break;
            case UpgradeTyp.Health:
                Debug.Log("Leben erhöht!");
                BasisPlayer.health += (int)u.Wert;
                StatManager.Instance.AddStat("gainedHealth", 1);
                break;
            case UpgradeTyp.UnverwundbarTimer:
                Debug.Log("Länger unverwundbar!");
                BasisPlayer.UnverwundbarTimer += (int)u.Wert;
                break;
            case UpgradeTyp.Dash:
                Debug.Log("Dash erhöht!");
                Dash.DashZahl += (int)u.Wert;
                break;
            /*case UpgradeTyp.Damage:
                Debug.Log("Schaden erhöht!");
                BasisPlayer.damage += (int)u.Wert;
                break;*/
            case UpgradeTyp.MehrSchuss:
                Debug.Log("Mehr Schuss!");
                BasisPlayer.Mehrfachschuss += (int)u.Wert;
                break;
            case UpgradeTyp.MehrCoins:
                Debug.Log("Mehr Coins!");
                BasisPlayer.coinDrop += (int)u.Wert;
                break;
            case UpgradeTyp.DashFrei:
                Debug.Log("Dash frei!");
                BasisPlayer.DashFreigeschaltet = true;
                break;
        }
    }
}