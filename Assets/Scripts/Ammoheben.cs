using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;

public class Ammoheben : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            SaveAmmo();
            Destroy(gameObject);
        }
    }

    void SaveAmmo() {
        SaveGame.Save<int>("Ammo", Schuss.ammo += 5);
    }
}
