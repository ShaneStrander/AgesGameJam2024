using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public Shooting shootingStyle;

    public float PowerDuration = 10f;
    public float TimeLeft;

    public bool Collided;

    // Start is called before the first frame update
    void Start()
    {
        shootingStyle = GameObject.FindWithTag("Shooter").GetComponent<Shooting>();
    }

    // Update is called once per frame
    void Update()
    {
       if (Collided)
        {
            PowerDuration -= Time.deltaTime;
        }
       else
        {
            PowerDuration = 10f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PowerUp")
        {
            Collided = true;
            while (PowerDuration <= 0)
            {
                shootingStyle.ShootStyle = 2;
            }
            
        }
        else if (collision.gameObject.tag == "PowerUp2")
        {
            Collided = true;
            while (PowerDuration <= 0)
            {
                shootingStyle.ShootStyle = 2;
            }
        }
        else if (collision.gameObject.tag == "PowerUp3") 
        {
            Collided = true;
            while (PowerDuration <= 0)
            {
                shootingStyle.ShootStyle = 2;
            }
        } 
        else
        {
            Collided = false;
            shootingStyle.ShootStyle = 1;
        }
    }
}
