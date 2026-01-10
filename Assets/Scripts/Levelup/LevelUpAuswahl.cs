using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using BayatGames.SaveGameFree;

public class LevelUpAuswahl : MonoBehaviour {
    //Hier Buttons zuweisen
    public GameObject LevelupSpeedUpgrade;
    public GameObject LevelupDamageUpgrade;
    public GameObject LevelupDashFreischalten;
    public GameObject LevelupWurfmesserFreischalten;
    public GameObject LevelupMehrfachschuss;
    public GameObject LevelupMuniDropErhöhen;
    public GameObject LevelupGeldDropErhöhen;
    public GameObject LevelupAllDrop;
    public GameObject LevelupDropChance;
    public static bool DashFreigeschaltet = false;
    public static bool WurfmesserFreigeschaltet = false;

    
    public void DashFreischalten() {
        bool DashFreigeschaltet = true;
        Save.SaveDashFreigeschaltet();
    }

    public void WurfmesserFreischalten() {
        WurfmesserFreigeschaltet = true;
    }

    public void SpeedUpgrade() {
        BasisPlayer.speed += 0.1f;
    }

    public void MuniDropUpgrade() {
        BasisPlayer.MuniDrop++;
    }

    public void GeldDropUpgrade() {
        BasisPlayer.GeldDrop++;
    }

    public void AllDrop() {
        BasisPlayer.AllDrop = true;
    }

    public void DropChance() {
        BasisPlayer.AdditionalDropChance += 10;
    }

    public void Mehrfachschuss() {
        BasisPlayer.Mehrfachschuss++;
    }


    public void ZufallsWahl() {
        int random = Random.Range(1, 8);
        if (random == 1) {
            DashFreischalten();
        } else if (random == 2) {
            WurfmesserFreischalten();
        } else if (random == 3) {
            SpeedUpgrade();
        } else if (random == 4) {
            MuniDropUpgrade();
        } else if (random == 5) {
            GeldDropUpgrade();
        } else if (random == 6) {
            AllDrop();
        } else if (random == 7) {
            DropChance();
        } else if (random == 8) {
            Mehrfachschuss();
        }
    }
}