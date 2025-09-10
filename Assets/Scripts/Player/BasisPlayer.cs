using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasisPlayer : MonoBehaviour {
    //Hauptsächlich für Levelup nötig
    public static float speed = 1.6f;
    public static int MuniDrop = 1;
    public static int GeldDrop = 1; //Wie viel Geld man beim Aufsammeln der Münzen bekommt
    public static int AdditionalDropChance;
    public static bool AllDrop = false; //Alle Monster dropen Muni/Geld
    public static int Mehrfachschuss = 1; //Zeigt wie viele Schüsse aufeinmal geschossen werden
}