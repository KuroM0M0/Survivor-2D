using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class BasisShop : MonoBehaviour {
    public TMP_Text Geldanzeige;
    public static int money;

    void Start() {
        money = Load.LoadCoin();
    }


    public void OnClickBack() {
        SceneManager.LoadScene("Game");
        Schuss.ammo = Load.LoadAmmo();
        Leben.health = Load.LoadLeben();
        Wurfmesser.wurfmesserAnzahl = Load.LoadWurfmesser();
        Bewegung.PlayerPos = Load.LoadPosition();
        Load.LoadSpawnedEnemys();
        Menü.IsLoaded = true;
    }

    public void MoneyChange(int kosten) {
        money += kosten;
        Save.SaveCoin();
    }
}