using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchadensTrankLifeTime : MonoBehaviour
{
    GameObject target;
    float lifetime = 1f;
    public float speed = 5f;
    float FollowTime = 0.1f;
    Vector2 FollowDirection;


    void Start() {
        target = GameObject.Find("Spieler");
    }


    void Update() {
        Destroy(gameObject, lifetime);
        FollowTime -= Time.deltaTime;

        if(FollowTime > 0) {
            FollowDirection = target.transform.position - transform.position;
            FollowDirection.Normalize();
            
            transform.Translate(FollowDirection * Time.deltaTime * speed);
        } else {
            transform.Translate(FollowDirection * Time.deltaTime * speed);
        }
    }


    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            Destroy(gameObject);
        }
    }
}