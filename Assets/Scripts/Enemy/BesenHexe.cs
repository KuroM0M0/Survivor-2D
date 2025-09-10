using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BesenHexe : MonoBehaviour
{
    int health = 10;
    float speed; //wird später definiert weil mit Besen schneller als ohne
    public string EnemyType = "BesenHexe";

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Schwert") || other.CompareTag("Bullet")) {
            health--;
        }
    }
}