using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootScript : MonoBehaviour
{

    public float EnemyFireRate = 1f;
    public float EnemyNextFire = 0f;

    public Transform enemyFirePoint;
    public GameObject enemyBullet;

    public float enemyBulletSpeed = 10f;
    public GameObject player;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float agroRange = Vector3.Distance(player.transform.position, transform.position);
        if (Time.time > EnemyNextFire && agroRange < 18)
        {
            EnemyShoot();
            EnemyFireDelay();
        }
    }

    public virtual void EnemyShoot()
    {
        EnemyNextFire = Time.time + EnemyFireRate;
        GameObject activeEnemyBullet = Instantiate(enemyBullet, enemyFirePoint.position, enemyFirePoint.rotation);
        Rigidbody2D rb = activeEnemyBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(enemyFirePoint.up * enemyBulletSpeed, ForceMode2D.Impulse);

    }

    IEnumerator EnemyFireDelay() 
    {
        yield return new WaitForSeconds(EnemyFireRate);
    }
}