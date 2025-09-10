using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Leben : MonoBehaviour
{
    public static int health;
    public GameObject Leben1;
    public GameObject Leben2;
    public GameObject Leben3;
    int UnverwundbarTimer = 2;      //Sekunden
    bool UnverwundbarBool = false;



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
            SceneManager.LoadScene("Highscore");
        }
    }



    void OnTriggerEnter2D(Collider2D other) {
        if(UnverwundbarBool == false) {
            if(other.CompareTag("Enemy")) {
            StartCoroutine(Unverwundbar());
            health--;
            Save.SaveLeben();
            }

        if(other.CompareTag("SchadensTrank")) {
            StartCoroutine(Unverwundbar());
            health -= 2;
            Save.SaveLeben();
            }

        if(other.CompareTag("Knochen")) {
            StartCoroutine(Unverwundbar());
            health--;
            Save.SaveLeben();
            }
        }
        if(other.CompareTag("Boss")) {
            StartCoroutine(Unverwundbar());
            health-= 2;
            Save.SaveLeben();
        }
        
    }

    IEnumerator Unverwundbar() {
        UnverwundbarBool = true;
        yield return new WaitForSeconds(UnverwundbarTimer);
        UnverwundbarBool = false;
    }
}