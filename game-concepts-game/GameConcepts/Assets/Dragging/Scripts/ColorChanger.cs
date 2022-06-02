using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ColorChangeButton.ActivatingColor += SelfColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SelfColor(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        col.gameObject.GetComponent<SpriteRenderer>().color = this.GetComponent<SpriteRenderer>().color;
    }
}
