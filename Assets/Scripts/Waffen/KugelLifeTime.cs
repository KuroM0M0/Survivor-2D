using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KugelLifeTime : MonoBehaviour
{

    public float lifetime = 5f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy") || other.CompareTag("Boss")) {
            Destroy(gameObject);
        }
    }
}