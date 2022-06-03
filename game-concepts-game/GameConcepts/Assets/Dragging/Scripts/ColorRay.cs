using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorRay : MonoBehaviour
{
    private Color rayColor;

    private float r, b, g;
    // Start is called before the first frame update
    void Start()
    {
        SetRayColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetRayColor()
    {
        r = GetComponent<SpriteRenderer>().color.r;
        b = GetComponent<SpriteRenderer>().color.b;
        g = GetComponent<SpriteRenderer>().color.g;
        // if (r > 0)
        // {
        //     rayColor = new Color(1f, 0f, 0f,0f);
        // }
        // else if (b > 0)
        // {
        //     rayColor = new Color(0f, 0f, 1f,0f);
        // }
        // else
        // {
        //     rayColor = new Color(0f, 1f, 0f,0f);
        // }
        if (r > 0)
        {
            //Red
            rayColor = new Color(0f, 0.01f, 0.01f,0f);
        }
        else if (b > 0)
        {
            rayColor = new Color(0.01f, 0.01f, 0f,0f);
        }
        else
        {
            rayColor = new Color(0.01f, 0f, 0.01f,0f);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        print("Hit");
        other.gameObject.GetComponent<SpriteRenderer>().color -= rayColor;
        
        if (other.gameObject.GetComponent<SpriteRenderer>().color.r < 0)
            other.gameObject.GetComponent<SpriteRenderer>().color =  
                new Color(0f, other.gameObject.GetComponent<SpriteRenderer>().color.g,
                other.gameObject.GetComponent<SpriteRenderer>().color.b, 1f);
        
        if (other.gameObject.GetComponent<SpriteRenderer>().color.b < 0)
            other.gameObject.GetComponent<SpriteRenderer>().color = 
            new Color(other.gameObject.GetComponent<SpriteRenderer>().color.r, 
                other.gameObject.GetComponent<SpriteRenderer>().color.g,
                0, 1f);
        
        if (other.gameObject.GetComponent<SpriteRenderer>().color.g < 0)
            other.gameObject.GetComponent<SpriteRenderer>().color = 
            new Color(other.gameObject.GetComponent<SpriteRenderer>().color.r, 0,
                other.gameObject.GetComponent<SpriteRenderer>().color.b, 1f);
        
        print(other.gameObject.GetComponent<SpriteRenderer>().color);
    }
}
