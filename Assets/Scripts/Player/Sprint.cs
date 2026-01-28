using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprint : BasisPlayer
{
    float sprintSpeed;
    void Start() {
        sprintSpeed = GameManager.Instance.normalSpeed + 1;
    }
    
    void Update() {
        if(Input.GetKeyDown(KeyCode.LeftShift)) {
            speed = sprintSpeed;
        } else if(Input.GetKeyUp(KeyCode.LeftShift)) {
            speed = normalSpeed;
        }
    }
}
