using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    public static int score = 0;
    public static int highScore;
    public Text Endscore;

    void Update() {
        if(highScore < score) {
            highScore = score;
        }

        if(Endscore != null) {
            Endscore.text = "Score: " + score;
        }
    }
}