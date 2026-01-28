using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;

public class Wurfmesser : MonoBehaviour
{
    public static int wurfmesserStat;
    public GameObject wurfmesserPrefab;
    float Speed = 6f;
    public float Schussrate = 1f;
    private Rigidbody2D rb;
    bool ready = true;

    void Update() {
        if(Input.GetKey(KeyCode.Q)) {
            if(GameManager.Instance.wurfmesser >= 1 && ready && Pause.pausiert == false) {
                ready = false;
                Debug.Log("Test");

                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 direction = mousePosition - rb.position;
                GameObject wurfmesser = Instantiate(wurfmesserPrefab, rb.position, Quaternion.identity);

                // Rigidbody vom Messer holen
                Rigidbody2D wurfmesserRB = wurfmesser.GetComponent<Rigidbody2D>();
            
                // Messer in die berechnete Richtung schießen
                wurfmesserRB.linearVelocity = direction.normalized * Speed;
                GameManager.Instance.wurfmesser--;
                wurfmesserStat++;
                Save.SaveWurfmesser();
                if(Save.Stats.ContainsKey("Wurfmesser")) {
                    Save.Stats["Wurfmesser"] = wurfmesserStat;
                } else {
                    Save.Stats.Add("Wurfmesser", wurfmesserStat);
                }*/
                StartCoroutine(WurfCool());
            }
        }
    }

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    IEnumerator WurfCool() {
        yield return new WaitForSeconds(1);
        ready = true;
    }
}