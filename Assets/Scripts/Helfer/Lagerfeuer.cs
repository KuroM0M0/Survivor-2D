using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lagerfeuer : MonoBehaviour
{

    public int regenerationTimer = 10;
    public int Haltbarkeit = 3;
    public bool istBeimFeuer = false;
    public bool regenerationAn = false;
    
   
    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            istBeimFeuer = true;
        } 
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            istBeimFeuer = false;
        }
    }

    void Update() {
        if(istBeimFeuer == true && Leben.health < 3 && !regenerationAn) {
            StartCoroutine(Regenerieren());
        }

        if(Haltbarkeit == 0) {
            Destroy(gameObject);
        }

        


    }

    IEnumerator Regenerieren() {
        if(istBeimFeuer == true) {
            regenerationAn = true;
            yield return new WaitForSeconds(regenerationTimer);
            if(istBeimFeuer == true) {
                Leben.health++;
                Save.SaveLeben();
                Haltbarkeit--;
            }
            regenerationAn = false;
        }
    }
}