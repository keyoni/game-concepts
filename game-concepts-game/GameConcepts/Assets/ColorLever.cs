using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ColorLever : MonoBehaviour
{
    private Color leverColor;

    public float leverAngle;
    public  float colorLevel;
    public static event Action<Color> SendNewColor;
    // Start is called before the first frame update
    void Start()
    {
       leverColor = GetComponent<SpriteRenderer>().color;
       print(leverColor);
       Rotatable.AngleChanged += SetAngle;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetAngle()
    {
        leverAngle = this.GetComponent<Rotatable>().currentAngle;
        colorLevel = leverAngle / 180;
    }

    void GetColor()
    {
        print("Sending From " +this.gameObject.name);
  
        float r, b, g;
        if (leverColor.r > 0.5f)
        {
            r = 1f;
            b = colorLevel;
            g = colorLevel;
        } else if (leverColor.b > 0.5f )
        {
            b = 1f;
            r = colorLevel;
            g = colorLevel;
        }
        else
        {
            g = 1f;
            b = colorLevel;
            r = colorLevel;
        }
        
        //print(r+""+g+" "+b);
        Color newColor = new Color(r, g, b);
        print(newColor);
        SendNewColor?.Invoke(newColor);
     
        
        
    }
}
