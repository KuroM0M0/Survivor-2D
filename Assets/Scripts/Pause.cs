using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject PauseMenü;
    public static bool pausiert;


    void Start()
    {
        PauseMenü.SetActive(false);
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(pausiert) {
                OnResume();
            } else {
                OnPause();
            }
        }
    }

    public void OnPause() {
        PauseMenü.SetActive(true);
        Time.timeScale = 0f;
        pausiert = true;
    }

    public void OnResume() {
        PauseMenü.SetActive(false);
        Time.timeScale = 1f;
        pausiert = false;
    }
}
