using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gras : MonoBehaviour {
    int SpawnChance = 20;
    //int Zufall; //Zufallszahl 1-100
    int Lebensdauer = 20;
    public GameObject GrasPrefab;
    float GrasChangeSpeed = 0.5f;
    public string EnemyType = "Gras";


    void Update() {
       // Zufall = Random.Range(1, 100);
    }

    void Start() {
        StartCoroutine(Lebenszeit());
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            Bewegung.speed -= GrasChangeSpeed;
        }

        if(other.CompareTag("Schwert")) {
            Destroy(gameObject);
        }
    }

    void Spawn() {
        if(SpawnChance <= GameManager.Zufall) {
            Instantiate(GrasPrefab, transform.position, Quaternion.identity);
        }
    }

    IEnumerator Lebenszeit() {
        yield return new WaitForSeconds(Lebensdauer);
        Destroy(gameObject);
    }
}