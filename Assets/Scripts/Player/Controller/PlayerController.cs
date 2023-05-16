using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float currentHealth = 10f;
    public float maxHealth = 10f;
    public Image healthBar;
        

    [FormerlySerializedAs("playerRB")] public Rigidbody2D playerRb;



    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    private void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(currentHealth / maxHealth, 0, 1f);

        if (currentHealth <= 0) 
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            SceneManager.LoadScene("Lobby");
        }
        if(currentHealth > maxHealth) 
        {
            currentHealth = maxHealth;
        }
    }
    private void OnLevelWasLoaded(int level)
    {
        transform.position = new Vector3(25, 5, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet")) 
        {
            TakeDamage();
        }
    }

    public void TakeDamage() 
    {
        currentHealth -= 1;
        
            
    }
    
}


