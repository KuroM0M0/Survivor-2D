using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BayatGames.SaveGameFree;

public class Highscore : MonoBehaviour
{
    public static int score = 0;
    int LocalScore;
    public Text Endscore;

    void Update() {
        if (Endscore != null) {
            Endscore.text = "Score: " + score;
            if(LocalScore < score) {
                Save.SaveScore();
            }
        }
    }

    void Start() {
        SaveGame.Encode = false;
        LocalScore = Load.LoadHighscore();
    }
}