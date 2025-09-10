using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bewegung : MonoBehaviour
{
    public static float speed = 1.6f;
    public static Vector2 PlayerPos;


    void OnApplicationQuit() {
        Save.SavePlayerPos();
    }

    void Start() {
        if(Menü.IsLoaded == true) {
            transform.position = Load.LoadPosition();
        }
        speed = Load.LoadSpeed();
    }

    void Update() {
        PlayerPos = transform.position;
        Movement();
    }

   public void Movement()
    {
        Vector3 rechts = Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(rechts);
        Vector3 hoch = Vector3.up * Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(hoch);
    }
}