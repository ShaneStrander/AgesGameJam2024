using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject shooter;
    public int Style;

    private void Start()
    {
        shooter = GameObject.FindWithTag("Shooter");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            shooter.GetComponent<Shooting>().ShootStyle = Style;
            shooter.GetComponent<Shooting>().PowerTimer = 0f;
            Destroy(gameObject);
        }
    }

}
