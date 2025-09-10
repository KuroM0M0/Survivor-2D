using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Zelt : BasisShop
{
    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            Save.SaveAll();
            SceneManager.LoadScene("Shop");
        }
    }



    public void OnClickLeben() {
        if(money >= 30 && Leben.health <3) {
            MoneyChange(-30);
            Leben.health++;
            Save.SaveLeben();
        }
    }



    public void OnClickMunition() {
        if(money >= 5) {
            MoneyChange(-5);
            Schuss.ammo += 24;
            Save.SaveAmmo();
        }
    }



    public void OnClickLagerfeuer() {
        if(money >= 80) {
            MoneyChange(-80);
        }
    }



    public void OnClickDash() {
        if(money >= 10) {
            MoneyChange(-10);
            Dash.DashZahl++;
            Save.SaveDash();
        }
        
    }

    public void OnClickWurfmesser() {
        if(money >= 5) {
            MoneyChange(-5);
            Wurfmesser.wurfmesserAnzahl++;
            Save.SaveWurfmesser();
        }
    }
}