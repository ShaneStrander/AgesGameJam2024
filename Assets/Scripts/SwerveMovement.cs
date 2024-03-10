using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveMovement : MonoBehaviour
{
    public float driftFactor = 0.05f;
    public float accelerationfactor = 3f;
    public float turnFactor = 3.5f;
    public float maxspeed = 10;
    float accelerationinput = 0;
    float steeringinput = 0;
    float VelocityVSup = 0;
    float rotationangle = 0;
    //private float horizontal;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    private void FixedUpdate()
    {
        KillOrthogonalVelocity();
        Applyingforce();
        ApplySteering();
        CheckPlayerBounds();

    }

    void Applyingforce()
    {
        //Calculates how much forward we are going
        VelocityVSup = Vector2.Dot(transform.up, rb.velocity);

        //Limit so you cant go faster than the max speed
        if (VelocityVSup > maxspeed && accelerationinput > 0) {
            return;
        }

        //Limit so we cant go faster than 50% max speed backwards
        if (VelocityVSup < -maxspeed * 1f && accelerationinput < 0)
        {
            return;
        }

        //Limit so we cant go faster in any direction accelerating
       if (rb.velocity.sqrMagnitude > maxspeed * maxspeed && accelerationinput > 0)
        {
           return;
        }

        //Apply drag if there is no acceleration and stops when letting go of the button



        //if (accelerationinput == 0)
       // {
            rb.drag = Mathf.Lerp(rb.drag, 3f, Time.deltaTime); ;
        //}
        //else rb.drag = 0;

        //Creates a force for the Ball
        Vector2 forward = transform.up * accelerationinput * accelerationfactor;
        // Vector2 reverse = -transform.up.normalized * accelerationinput * accelerationfactor;



        //Apply force and moves the ball forward
        //if (Input.GetKey("w"))
        // {
        rb.AddForce(forward);

       // }
       // else if (Input.GetKey("s")) 
            //{

       // }

    }

    void ApplySteering()
    {
        //Limit ball ability to turn when moving slowly
        float minspeed = (rb.velocity.magnitude / 1);
        minspeed = Mathf.Clamp01(minspeed);
        
        //Update rotation angle based on input
        rotationangle -= steeringinput * turnFactor * minspeed;

        //Apply steering by rotating the ball
        rb.MoveRotation(rotationangle);
        if (rotationangle <= -75) {
            rotationangle = -75;
        } else if (rotationangle >= 75) {
            rotationangle = 75;
        }
    }


    //Car physics stuff
    void KillOrthogonalVelocity() {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(rb.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(rb.velocity, transform.right);

       rb.velocity = forwardVelocity + rightVelocity * driftFactor;
    }

    //Creates the controls for the player (WASD)
    public void SetInputVector(Vector2 inputVector)
    {
        steeringinput = inputVector.x;
        accelerationinput = inputVector.y;
    }

    private void CheckPlayerBounds()
    {
        //Creates bounds for the player
    transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3, 3), Mathf.Clamp(transform.position.y, -4.4f, 4.4f), 0);
    }
}
