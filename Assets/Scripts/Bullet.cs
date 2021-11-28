using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    private float topBound = 15f;
    private float maxRange = 17f;

    private ScoreManager scoreM;

    private void Start()
    {
        scoreM = GetComponent<ScoreManager>();
    }

    private void Update()
    {
        if (transform.position.y > topBound)
        {
            Destroy(gameObject);
        }

        if (transform.position.x > maxRange)
        {
            Destroy(gameObject);
        }else if (transform.position.x < -maxRange)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            ScoreManager.instance.score += 1;
        }
    }
}