using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerController playerController;
    public GameObject player;
    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        playerController = player.GetComponent<PlayerController>();
        
        if (collision.CompareTag("Player")) 
        {
            playerController.currentHealth += 3;
        }
        Destroy(this.gameObject);
    }
}
