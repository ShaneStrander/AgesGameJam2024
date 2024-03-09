using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    SwerveMovement Swerve;

    // Start is called before the first frame update
    void Start()
    {
        Swerve = GetComponent<SwerveMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = Vector2.zero;

        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");
       
        Swerve.SetInputVector(inputVector);
    }
}
