using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Leben : BasisPlayer
{
    public GameObject Leben1;
    public GameObject Leben2;
    public GameObject Leben3;
    



    void Update() {
        if(health == 3) {
            Leben1.SetActive(true);
            Leben2.SetActive(true);
            Leben3.SetActive(true);
        } else if(health == 2) {
            Leben1.SetActive(true);
            Leben2.SetActive(true);
            Leben3.SetActive(false);
        } else if(health == 1) {
            Leben1.SetActive(true);
            Leben2.SetActive(false);
            Leben3.SetActive(false);
        } else {
            Leben1.SetActive(false);
            Leben2.SetActive(false);
            Leben3.SetActive(false);
        }


        if(health <= 0) {
            SaveNew.SaveAll();
            SceneManager.LoadScene("Highscore");
        }
    }


//Schadensberechnung
    void OnTriggerEnter2D(Collider2D other) {
        if(UnverwundbarBool == false) {
            if(other.CompareTag("Enemy")) {
                onDamage(1);
            }

            if(other.CompareTag("SchadensTrank")) {
                onDamage(2);
            }

            if(other.CompareTag("Knochen")) {
                onDamage(1);
            }

            if(other.CompareTag("Boss")) {
                onDamage(2);
            }
        }
    }

    
}