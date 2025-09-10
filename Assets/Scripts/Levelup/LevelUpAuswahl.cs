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

    public void GeldDrop() {
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
}