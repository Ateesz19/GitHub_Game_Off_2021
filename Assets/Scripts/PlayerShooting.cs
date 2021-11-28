using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private AudioSource audioS;

    private float bulletForce = 20f;

    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    void Update()
    {
        FireOnClick();
    }

    void FireOnClick()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            audioS.PlayOneShot(audioS.clip);
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
