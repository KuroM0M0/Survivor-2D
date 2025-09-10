using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;

public class Wurfmesser : MonoBehaviour
{
    public static int wurfmesserAnzahl;
    public static int wurfmesserStat;
    public GameObject wurfmesserPrefab;
    float Speed = 6f;
    public float Schussrate = 1f;
    float SchussrateTimer = 1f;
    private Rigidbody2D rb;

    void Update() {

        if(SchussrateTimer > 0) {
            SchussrateTimer -= 0.1f;
            }


        if(Input.GetKey(KeyCode.Q)) {

            if(wurfmesserAnzahl >= 1 && SchussrateTimer <= 0 && Pause.pausiert == false) {
                Debug.Log("Test");

                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 direction = mousePosition - rb.position;
                GameObject wurfmesser = Instantiate(wurfmesserPrefab, rb.position, Quaternion.identity);

                // Rigidbody vom Messer holen
                Rigidbody2D wurfmesserRB = wurfmesser.GetComponent<Rigidbody2D>();
            
                // Messer in die berechnete Richtung schießen
                wurfmesserRB.linearVelocity = direction.normalized * Speed;
                wurfmesserAnzahl--;
                wurfmesserStat++;
                Save.SaveWurfmesser();
                if(Save.Stats.ContainsKey("Wurfmesser")) {
                    Save.Stats["Wurfmesser"] = wurfmesserStat;
                } else {
                    Save.Stats.Add("Wurfmesser", wurfmesserStat);
                }
            }
        }
    }

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        SchussrateTimer = Schussrate;
    }
}