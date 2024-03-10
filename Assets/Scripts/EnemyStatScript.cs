using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatScript : MonoBehaviour
{
    public GameObject deathFrame;

    [SerializeField]
    private AudioClip clip;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            GameObject death = Instantiate(deathFrame, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(death, 1.5f);
            AudioSource.PlayClipAtPoint(clip,transform.position);
        }
    }
}
