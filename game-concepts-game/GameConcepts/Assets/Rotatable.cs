using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class Rotatable : MonoBehaviour
{
    private Vector3 mousePos;
    private Quaternion spriteStart;
    private bool isHeld = false;
    private Vector3 screenPos;
    private float angleOffset;
    public float currentAngle;
    public static event Action AngleChanged;
    public bool isLever;

    private void Start()
    {
        isLever = false;
    }

    private void OnMouseDown()
    {
        isHeld = true;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //print("Mouse" + mousePos);
        spriteStart = this.transform.localRotation;
        //print("Sprite" +
              //spriteStart.z);
        screenPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 vec3 = Input.mousePosition - screenPos;
        angleOffset = (Mathf.Atan2(transform.right.y, transform.right.x) - Mathf.Atan2(vec3.y, vec3.x)) * Mathf.Rad2Deg;


    }
    
    //https://www.youtube.com/watch?v=0eM5molItfE 

    private void OnMouseDrag()
    {
        print("MOVING" + this.gameObject.name);

       Vector3 vec3 = Input.mousePosition - screenPos;
        float angle = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg;
    
        if (isLever)
        {
            angle = RotateLever(angle);
        }
        

        transform.eulerAngles = new Vector3(0, 0, angle + angleOffset);
        //print(angle);
        currentAngle = angle;
        AngleChanged?.Invoke();

    }

     float RotateLever(float angle)
    {
        if (angle > -180 && angle < -100)
        {
            print("GREATER THAN 180");
            angle = 179;
        } else if (angle < 0)
        {
           
            print("LESS THAN 0");
            angle = 0;
        }

        return angle;
    }

    private void OnMouseUp()
    {
        isHeld = false;
    }

}
