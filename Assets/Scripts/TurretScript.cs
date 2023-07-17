using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1f, bulletSpeed;

    private Transform player;
    private float fireCountdown = 0f;

    private void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        fireCountdown = 10f / fireRate;
        InvokeRepeating("Shoot", 3f,1 / fireRate);
    }

    private void Update()
    {
        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 180;

        transform.rotation = Quaternion.Euler(0, 0, angle);
        

        fireCountdown -= Time.deltaTime;
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(-transform.right *
            bulletSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
     
            


    }
}
