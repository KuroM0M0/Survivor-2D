using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bewegung : BasisPlayer
{
    public static Vector2 PlayerPos;


    /*void OnApplicationQuit() {
        Save.SavePlayerPos();
    }*/

    /*void Start() {
        if(Menü.IsLoaded == true) {
            transform.position = Load.LoadPosition();
        }
        speed = Load.LoadSpeed();
    }*/

    void Update() {
        PlayerPos = transform.position;
        Movement();
    }

   public void Movement() {
        Vector3 rechts = Input.GetAxis("Horizontal") * speed * Time.deltaTime * Vector3.right;
        transform.Translate(rechts);
        Vector3 hoch = Input.GetAxis("Vertical") * speed * Time.deltaTime * Vector3.up;
        transform.Translate(hoch);
    }
}