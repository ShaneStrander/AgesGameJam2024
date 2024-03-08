using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
   private float horizontal;
   private float vertical;
    public float Speed;
   Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal") * Speed;
        vertical = Input.GetAxisRaw("Vertical") * Speed;
         rb.velocity = new Vector2(horizontal, vertical);
    }

    private void FixedUpdate()
    {
        //transform.position += new Vector3(Speed * Input.GetAxisRaw("Horizontal"), Speed * Input.GetAxisRaw("Vertical"), 0);
    }
}