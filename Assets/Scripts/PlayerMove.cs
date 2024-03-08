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
        //Vector3 movementDirection = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
       // transform.Translate(movementDirection * Speed * Time.deltaTime);
        horizontal = Input.GetAxisRaw("Horizontal") * Speed;
        vertical = Input.GetAxisRaw("Vertical") * Speed;
         rb.velocity = new Vector2(horizontal, vertical);
        CheckPlayerBounds();
    }

    private void FixedUpdate()
    {
        //transform.position += new Vector3(Speed * Input.GetAxisRaw("Horizontal"), Speed * Input.GetAxisRaw("Vertical"), 0);
    }

    private void CheckPlayerBounds() {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3, 3), Mathf.Clamp(transform.position.y, -3.5f, 5), 0);
    }
}