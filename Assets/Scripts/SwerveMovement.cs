using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveMovement : MonoBehaviour
{
    public float driftFactor = 0.05f;
    public float accelerationfactor = 0.05f;
    public float turnFactor = 3.5f;
    public float maxspeed = 6;
    float accelerationinput = 0;
    float steeringinput = 0;
    float VelocityVSup = 0;
    float rotationangle = 0;

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

        VelocityVSup = Vector2.Dot(transform.up, rb.velocity);

        if (VelocityVSup > maxspeed && accelerationinput > 0) {
            return;
        }

        if (VelocityVSup < maxspeed * 0.05f && accelerationinput < 0)
        {
            return;
        }

        if (rb.velocity.sqrMagnitude > maxspeed * maxspeed && accelerationinput > 0)
        {
            return;
        }

        if (accelerationinput == 0) {
            rb.drag = Mathf.Lerp(rb.drag, 3.0f, Time.deltaTime * 3);
    }   else rb.drag = 0;


        Vector2 forward = transform.up * accelerationinput * accelerationfactor;

        rb.AddForce(forward, ForceMode2D.Force);
    }

    void ApplySteering()
    {
        float minspeed = (rb.velocity.magnitude / 4);
        minspeed = Mathf.Clamp01(minspeed);
        
        
        rotationangle -= steeringinput * turnFactor * minspeed;

        rb.MoveRotation(rotationangle);
    }


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
      transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3, 3), Mathf.Clamp(transform.position.y, -4.4f, 1.4f), 0);
    }
}
