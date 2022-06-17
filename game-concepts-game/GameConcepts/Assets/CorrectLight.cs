using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectLight : MonoBehaviour
{
    private String lightColor;
    // Start is called before the first frame update
    void Start()
    {
        lightColor = gameObject.name;
        ColorCompare2.ColorMatch += lightOn;
        ColorCompare2.ColorFail += lightOff;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void lightOn(String light)
    {
        if (light.Equals(lightColor))
        {
            this.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
    }
    
    private void lightOff(String light)
    {
        if (light.Equals(lightColor))
        {
            this.GetComponent<SpriteRenderer>().color = Color.gray;
        }
    }

}
