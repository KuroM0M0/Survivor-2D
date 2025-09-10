using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{

    public static int DashStat = 0; //Für Stats
    public static int DashZahl = 2;

    public float cooldown = 10f;
    bool ready = true;


    void Update() {

        if(cooldown > 0) {
            cooldown -= Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.Y) && cooldown <= 0 && DashZahl > 0) {
            Bewegung.speed = 7;
            DashStat ++; //Für Stats
            ready = false;

            if(Save.Stats.ContainsKey("Dash")) {
                Save.Stats["Dash"] = DashStat;
            } else {
                Save.Stats.Add("Dash", DashStat);
            }
        }

        if(ready == false) {
            StartCoroutine(Dashcool());
        }
    }

    IEnumerator Dashcool() {
        yield return new WaitForSeconds(1);
        Bewegung.speed = 1.6f;
        cooldown = 10;
        ready = true;
    }
}