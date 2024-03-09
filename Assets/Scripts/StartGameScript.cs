using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameScript : MonoBehaviour
{
    public GameObject player;
    public GameObject shooter;
    public GameObject spawner;
    public GameObject pusherSpawner;
    public GameObject pusher;

    private GameObject shooterObject;
    private GameObject playerObject;
    private GameObject pusherObject;

    public void Start()
    {
        Quaternion rotation = Quaternion.Euler(0, 0, 180);
        pusherObject = Instantiate(pusher, pusherSpawner.transform.position, rotation);
        playerObject = Instantiate(player, transform.position, Quaternion.identity);
        shooterObject = Instantiate(shooter, spawner.transform.position, Quaternion.identity);
    }

    public void Update()
    {
        Vector3 offset = new Vector3(0f, 0.75f, 0f);
        Vector3 secondOffset = new Vector3(0f, -0.5f, 0f);
        spawner.transform.position = playerObject.transform.position + offset;
        pusherSpawner.transform.position = playerObject.transform.position + secondOffset;
        shooterObject.transform.position = spawner.transform.position;
        pusherObject.transform.position = pusherSpawner.transform.position;
    }
}
