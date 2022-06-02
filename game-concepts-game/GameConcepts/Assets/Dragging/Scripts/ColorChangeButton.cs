using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeButton : MonoBehaviour
{

    private List<Color> colors;

    private Color currentColor;

    private int currentIndex = 0;

    public static event Action<Color> ActivatingColor;

    // Start is called before the first frame update
    void Start()
    {
        colors = new List<Color>() {Color.red, Color.green, Color.blue};
        currentColor = colors[currentIndex];
        GetComponent<SpriteRenderer>().color = currentColor;

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        
        //Change the color of the color changers
        ActivatingColor?.Invoke(currentColor);
        //move to next color in list
        currentIndex++;
        if (currentIndex > colors.Count - 1)
        {
            currentIndex = 0;
        }
        Debug.Log(currentIndex +" "+  colors.Count);
        currentColor = colors[currentIndex];
        GetComponent<SpriteRenderer>().color = currentColor;
    }
}
    
