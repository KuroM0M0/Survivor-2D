using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprint : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift)) {
            Bewegung.speed = 3;
        } else {
            Bewegung.speed = 2;
        }
    }
}
