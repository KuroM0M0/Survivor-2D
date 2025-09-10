using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSpawn : MonoBehaviour
{
    public GameObject Shop;
    public int WaitForSpawn = 60;
    
    void Start() {
        StartCoroutine(Cooldown());
    }
    IEnumerator Cooldown() {
        yield return new WaitForSeconds(WaitForSpawn);
        Shop.SetActive(true);
    }
}