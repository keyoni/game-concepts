using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTimerTest : MonoBehaviour
{
    private float startTime;
    private float timeHeld = 0;
    private float totalTimeHeld = 0;

    private bool isHeld = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    // Update is called once per frame
    private void OnMouseDown()
    {
        startTime = Time.time;
        
    }

    private void OnMouseDrag()
    {
        timeHeld = Time.time - startTime;
        //print(Mathf.Round(timeHeld));
        
    }

    private void OnMouseUp()
    {
        totalTimeHeld += timeHeld;
        print("Last time: "+ timeHeld);
        print("Total time: " + totalTimeHeld);
        startTime = 0;
    }
}
