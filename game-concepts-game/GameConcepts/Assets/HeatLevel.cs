using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HeatLevel : MonoBehaviour
{
    private Color startColor;


    private void Start()
    {
        startColor = GetComponent<SpriteRenderer>().color;
        Rotatable.LeverLevel += ChangeColor;
    }

    private void ChangeColor(float num)
    {
        float colorLevel = num / 180;

        GetComponent<SpriteRenderer>().color = new Color(1, colorLevel, colorLevel);
    }
    
}
