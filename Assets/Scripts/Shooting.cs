using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera cam;

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    public float RateOfFire = 0.3f;
    public float ElapsedTime = 0f;

    public int ShootStyle = 1;

    public Transform spread1;
    public Transform spread2;


    Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        ElapsedTime += Time.deltaTime;

        switch (ShootStyle)
        {
            case 1:
                RateOfFire = 0.4f;
                if (Input.GetButton("Fire1") && ElapsedTime >= RateOfFire)
                {
                    Shoot();
                    ElapsedTime = 0;
                }
                break;
            case 2:
                RateOfFire = 0.6f;
                if (Input.GetButton("Fire1") && ElapsedTime >= RateOfFire)
                {
                    SpreadShoot();
                    ElapsedTime = 0;
                }
                break;
            case 3:
                RateOfFire = 0.8f;
                if (Input.GetButton("Fire1") && ElapsedTime >= RateOfFire)
                {
                    StartCoroutine(BurstShoot());
                    ElapsedTime = 0;
                }
                break;
           
        }
    }

    private void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    public void Shoot()
    {
        GameObject bullet =  Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
    
    public void SpreadShoot()
    {
        GameObject bullet =  Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

        GameObject bullet2 = Instantiate(bulletPrefab, spread1.position, spread1.rotation);
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        rb2.AddForce(spread1.up * bulletForce, ForceMode2D.Impulse);

        GameObject bullet3 = Instantiate(bulletPrefab, spread2.position, spread2.rotation);
        Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
        rb3.AddForce(spread2.up * bulletForce, ForceMode2D.Impulse);
    }
    
    IEnumerator BurstShoot()
    {
        int BulletCount = 3;
        float BurstRate = 0.1f;

        for (int i = 0; i < BulletCount; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            yield return new WaitForSeconds(BurstRate);
        }
    }
}
