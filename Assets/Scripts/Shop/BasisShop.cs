using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class BasisShop : MonoBehaviour {

    public void OnClickBack() {
        SaveNew.SaveAll();
        SceneManager.LoadScene("Game");
        /*Schuss.ammo = Load.LoadAmmo();
        BasisPlayer.health = Load.LoadLeben();
        Wurfmesser.wurfmesserAnzahl = Load.LoadWurfmesser();
        Bewegung.PlayerPos = Load.LoadPosition();
        Load.LoadSpawnedEnemys();*/
        LoadNew.LoadAll();
        Menü.IsLoaded = true;
    }

    public void MoneyChange(int kosten) {
        GameManager.Instance.money += kosten;
        if(kosten < 0) {
            StatManager.Instance.AddStat("spentCoins", kosten);
        } else {
            StatManager.Instance.AddStat("earnedCoins", kosten);
        }
    }
}