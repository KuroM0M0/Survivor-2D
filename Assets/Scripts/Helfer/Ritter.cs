using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ritter : MonoBehaviour
{

    public int health = 10;
    public int speed = 2;
    int Zufall;
    int DropChance = 10;
    GameObject target;
    public GameObject DropPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Enemy"); 
        Zufall = Random.Range(0, 100);

        if(health <= 0) {
            if(Zufall < DropChance) {
                GameObject Drop = Instantiate(DropPrefab, transform.position, Quaternion.identity);
            }
            GameManager.exp -= 10;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy")) {
            health--;
        }
    }
}
