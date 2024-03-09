using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private float rotZ;
    public float RotSpeed;
    public bool ClockwiseRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ClockwiseRotation == false) {
            rotZ += Time.deltaTime * RotSpeed;
        } else {
            rotZ += -Time.deltaTime * RotSpeed;
        }
        transform.rotation = Quaternion.Euler(0,0,rotZ);
    }
}
