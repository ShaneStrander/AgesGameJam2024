using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float health = 100f;
    public GameObject healthBar;

    public void Start()
    {
        healthBar = GameObject.FindWithTag("Health");
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            TakeDamage();
        }
    }

    public void Update()
    {

        if (health <= 0)
        {
            Time.timeScale = 0;
        }
    }

    public void TakeDamage()
    {
        health -= 25;
        healthBar.GetComponent<Image>().fillAmount = health / 100f;
    }
}
