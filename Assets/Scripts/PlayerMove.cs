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
        //Needed for Both
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        //Rigidbody needed
        rb.velocity = new Vector3(horizontal, vertical).normalized * Speed;

        //No Rigidbody
       // Vector3 movement = new Vector3(horizontal, vertical, 0);
        //transform.Translate(movement * Speed * Time.deltaTime);
        
        CheckPlayerBounds();
    }

    private void FixedUpdate()
    {
        //transform.position += new Vector3(Speed * Input.GetAxisRaw("Horizontal"), Speed * Input.GetAxisRaw("Vertical"), 0);
    }

    private void CheckPlayerBounds() {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3, 3), Mathf.Clamp(transform.position.y, -4.4f, 4.4f), 0);
    }
}