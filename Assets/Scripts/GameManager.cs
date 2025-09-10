using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static int Zufall;
    public static float exp;

    void Update() {
        Zufall = Random.Range(1, 100);

    }
}