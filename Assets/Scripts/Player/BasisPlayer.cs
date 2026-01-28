using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasisPlayer : MonoBehaviour {
    //Hauptsächlich für Levelup nötig
    public static int health {
        get { return GameManager.Instance.health; }
        set { GameManager.Instance.health = value; }}
    public static int UnverwundbarTimer = 1; //Sekunden
    public static float speed {
        get { return GameManager.Instance.speed; }
        set { GameManager.Instance.speed = value; }}
    public static float normalSpeed {
        get { return GameManager.Instance.normalSpeed; }
        set { GameManager.Instance.normalSpeed = value; }}
    public static int ammoDrop = 1;
    public static int coinDrop = 1; //Wie viel Geld man beim Aufsammeln der Münzen bekommt
    public static float AdditionalDropChance;
    public static bool AllDrop = false; //Alle Monster dropen Muni/Geld
    public static int Mehrfachschuss = 1; //Zeigt wie viele Schüsse aufeinmal geschossen werden
    public static bool DashFreigeschaltet = false;
    public static bool WurfmesserFreigeschaltet = false;
    public static bool hatSchwert = false;
    public bool UnverwundbarBool = false;

    public void onDamage(int Damage) {
        StartCoroutine(Unverwundbar());
        GameManager.Instance.health -= Damage;
        StatManager.Instance.AddStat("damageTaken", Damage);
    }

    public IEnumerator Unverwundbar() {
        UnverwundbarBool = true;
        yield return new WaitForSeconds(UnverwundbarTimer);
        UnverwundbarBool = false;
    }
}