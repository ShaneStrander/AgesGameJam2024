using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameScript : MonoBehaviour
{
    public GameObject player;
    public GameObject shooter;
    public GameObject spawner;

    private GameObject shooterObject;
    private GameObject playerObject;

    public void Start()
    {

        playerObject = Instantiate(player, transform.position, Quaternion.identity);

        shooterObject = Instantiate(shooter, spawner.transform.position, Quaternion.identity);
    }

    public void Update()
    {
        Vector3 offset = new Vector3(0f, 1f, 0f);
        spawner.transform.position = playerObject.transform.position + offset;
        shooterObject.transform.position = spawner.transform.position;
    }
}
