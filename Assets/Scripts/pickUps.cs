using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUps : MonoBehaviour
{
    public weaponManager weaponManagerScript;
    public GameObject health;
    public GameObject gun;
    public GameObject ammo;
    //public GameObject coin;

    public void Awake()
    {
        weaponManager weaponManagerScript = GetComponent<weaponManager>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            health.SetActive(true);
           // ammo.SetActive(true);
            
        }
        
    }
}
