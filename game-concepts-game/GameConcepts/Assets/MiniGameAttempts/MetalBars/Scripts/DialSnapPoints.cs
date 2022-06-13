using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class DialSnapPoints : MonoBehaviour
{
    bool occupied = false;

    public int value;

    public static event Action<int> DialSet;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        print("Hit");
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (!occupied)
        {
            if (other.gameObject.CompareTag("Handle"))
            {
                Rotatable dial = (Rotatable) other.gameObject.GetComponentInParent(typeof(Rotatable));
                if (dial.isHeld == false)
                {
                    //print("ShouldStick");
                    //other.gameObject.transform.parent.LookAt(this.transform,Vector3.up);
                    var parent = other.gameObject.transform.parent;
                    // print("Snap Pos" + transform.position);
                    // print("Parent" + parent.position);
                    Vector3 currentAngle = parent.eulerAngles;
                   // print("current Angle" + currentAngle);
                    Vector3 updatedAngle = (this.transform.position - parent.position);
                    //print("updated Angle" + updatedAngle);
                    parent.up = updatedAngle;
                    occupied = true;
                    DialSet?.Invoke(value);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        occupied = false;
    }
}
