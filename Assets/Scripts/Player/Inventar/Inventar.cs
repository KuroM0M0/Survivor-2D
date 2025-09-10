using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventar : MonoBehaviour
{
    public List<GameObject> items;
    public GameObject AktuellesItem;
    private Transform player;
    private GameObject swordHolder;


    void Start() {
        player = GetComponent<Transform>();

        swordHolder = new GameObject("swordHolder");
        swordHolder.transform.position = player.position;
        
    }


    public void AddItem(GameObject item) {
        items.Add(item);
    }


    public void RemoveItem(GameObject item) {
        items.Remove(item);
    }

    void OnTriggerStay2D(Collider2D other) {
        if(Input.GetKey(KeyCode.E)) {
            GameObject otherGameObject = other.GetComponent<Collider2D>().gameObject;
            if(!other.CompareTag("Enemy") && !other.CompareTag("Player") && !items.Contains(otherGameObject)) {
                items.Add(otherGameObject);
                otherGameObject.SetActive(false);
            }
        }
    }


    public void Anzeige() {

    }


    void Update() {
        for(int i = 1; i <= 9; i++) {
            if(Input.GetKeyDown(i.ToString())) {
                if(i-1 < items.Count) {
                    AktuellesItem = items[i-1];
                    AktuellesItem.SetActive(true);
                    
                    AktuellesItem.transform.position = swordHolder.transform.position;
                    AktuellesItem.transform.rotation = swordHolder.transform.rotation; // Setzt die Rotation auf null
                    AktuellesItem.transform.SetParent(swordHolder.transform);
                } else {
                    if(AktuellesItem == null) {
                        continue;
                    }
                    AktuellesItem.SetActive(false);
                    AktuellesItem = null;
                }
            }
        }

        //Schwert
        if(AktuellesItem != null) {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = mousePosition - player.position;

            // Setze die Position des Schwerts um den Spieler herum
            swordHolder.transform.position = player.position;

            // Berechne den Winkel und rotiere das Schwert
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            swordHolder.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // Bewege das Schwert zum aktuellen Winkel
            swordHolder.transform.position += swordHolder.transform.right * 0.35f;
        } 
    }
}