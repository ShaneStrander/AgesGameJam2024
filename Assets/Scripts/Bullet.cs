using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public GameObject hitEffect;

    public GameObject shooter;
    public Shooting shootStyle;

    public GameObject bulletFab;

    private float angle;

    private void Start()
    {
        shooter = GameObject.FindWithTag("Shooter");
        shootStyle = shooter.GetComponent<Shooting>();
    }

    private void Update()
    {
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 3f);
        if (collision.gameObject.tag == "enemy" && shootStyle.ShootStyle != 4)
        {
            Destroy(gameObject);
        }
        
        if (shootStyle.ShootStyle == 4 && collision.gameObject.tag == "enemy")
        {
            for (int i = 0; i < 5; i++)
            {
                Quaternion target = Quaternion.Euler(0, 0, angle);
                GameObject bullet = Instantiate(bulletFab, collision.transform.position, target);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(bullet.transform.up * shootStyle.bulletForce, ForceMode2D.Impulse);
                angle = angle + 72;
            }
            Destroy(gameObject);
            //hehe
        }
    }
}
