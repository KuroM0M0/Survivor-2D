using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using BayatGames.SaveGameFree;

public class Coin : BasisShop
{
    void Start() {
        SaveGame.Encode = false;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            MoneyChange(BasisPlayer.coinDrop);
            Destroy(gameObject);
        }
    }
}