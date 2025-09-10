using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasisEnemy : MonoBehaviour
{
    public string EnemyType;
    public int health;
    static protected GameObject target;
    protected float speed;
    public GameObject CoinPrefab;
    public GameObject DropPrefab;
    protected float distance;
    protected float DistanzZumSpieler;
    protected Transform player;
    public static float xp;


    protected void Distanz() {
        if(target && player) {
            distance = Vector2.Distance(player.position, transform.position);
            if(distance <= DistanzZumSpieler) {
                speed = 0;
            } else {
                speed = getLocalSpeed();
            }
        }
    }

    protected abstract float getLocalSpeed();

    protected void Eingefroren() {
        if(ItemEinfrieren.eingefroren) {
            speed = 0;
        } else {
            speed = getLocalSpeed();
        }
    }

    protected void setXP() {
        xp = health/2;
        if (target) {
            player = target.GetComponent<Transform>();
        }
    }
}