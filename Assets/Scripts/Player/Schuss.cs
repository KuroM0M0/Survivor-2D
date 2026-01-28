using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BayatGames.SaveGameFree;

public class Schuss : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Rigidbody2D rb;
    float bulletSpeed = 6f;
    public float Schussrate = 10f;
    float SchussrateTimer;
    public static int ammo;
    public Text Munition;
    public Text WurfmesserMunition;



    void Start()
    {
        // Holen der Referenz auf den Rigidbody des Waffe-GameObjects
        rb = GetComponent<Rigidbody2D>();
        Munition.text = ammo.ToString();
        WurfmesserMunition.text = GameManager.Instance.wurfmesser.ToString();
    }



    void Update()
    {
        Munition.text = "Munition: " + ammo;
        WurfmesserMunition.text = "Wurfmesser: " + GameManager.Instance.wurfmesser;
        
        if(SchussrateTimer > 0) {
            SchussrateTimer -= 0.1f;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if(ammo >= 1 && SchussrateTimer <= 0 && Pause.pausiert == false) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = mousePosition - rb.position;
            GameObject bullet = Instantiate(bulletPrefab, rb.position, Quaternion.identity);
            
            // Rigidbody der Kugel holen
            Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
            
            // Kugel in die berechnete Richtung schießen
            bulletRB.linearVelocity = direction.normalized * bulletSpeed;
            ammo--;
            SchussrateTimer = Schussrate;
            }
        }
    }
}