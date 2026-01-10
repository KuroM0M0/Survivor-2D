using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using BayatGames.SaveGameFree;

public class Levelup : MonoBehaviour
{
    public TMP_Text EpAnzeige;
    public TMP_Text LevelAnzeige;
    

    void Update() {
        UpdateUI();
    }

    void UpdateUI() {
        int Level = Load.LoadLevel();
        if (LevelAnzeige != null) LevelAnzeige.text = "Level: " + Level;
    }
}