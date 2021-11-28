using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private SpawnManager spawnManager;
    public Rigidbody2D enemyRb;
    public GameObject player;

    private UIManager UIMan;

    public float speed = 2.0f;
    private float maxY = 11.0f;
    private float minY = -10.0f;
    private float maxX = 17.0f;
    private float maxAcc = 1.0f;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");

        UIMan = GetComponent<UIManager>();
    }

    void Update()
    {
        LookAtPlayer();
        if (transform.position.y < minY || transform.position.y > maxY || transform.position.x > maxX || transform.position.x < -maxX)
        {
            Destroy(gameObject);
        }
    }

    void LookAtPlayer()
    {
        if (player != null)
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            enemyRb.AddForce(lookDirection * maxAcc);
        }else
        {
            //
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
