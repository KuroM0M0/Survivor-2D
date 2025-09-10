using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEinfrieren : MonoBehaviour
{

    int GefrorenTimer = 4;
    float BossGefrorenTimer = 1.5f;
    public static bool eingefroren = false;
    public static bool bossEingefroren = false;

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            eingefroren = true;
            bossEingefroren = true;
            StartCoroutine(Gefroren());
            StartCoroutine(BossGefroren());
            Destroy(GetComponent<Collider2D>());
            Destroy(GetComponent<SpriteRenderer>());
        }
    }

    IEnumerator Gefroren() {
        yield return new WaitForSeconds(GefrorenTimer);
        eingefroren = false;
    }

    IEnumerator BossGefroren() {
        yield return new WaitForSeconds(BossGefrorenTimer);
        bossEingefroren = false;
    }
}