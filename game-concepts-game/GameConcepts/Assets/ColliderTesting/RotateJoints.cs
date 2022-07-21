using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateJoints : MonoBehaviour
{
    private HingeJoint2D _hingeJoint2D;

    private float currentAngle = 0f;
    // Start is called before the first frame update
    void Start()
    {
        _hingeJoint2D = GetComponent<HingeJoint2D>();
    }

    // Update is called once per frame
    void Update()
    { 
       

    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.blue;  
        _hingeJoint2D.useMotor = true;
    }

    private void OnMouseDrag()
    {
      
    }

    private void OnMouseUp()
    {
        _hingeJoint2D.useMotor = false;
        GetComponent<SpriteRenderer>().color = Color.white;  
       
    }
}
