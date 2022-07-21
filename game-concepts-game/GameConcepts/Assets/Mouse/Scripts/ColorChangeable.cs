using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeable : MonoBehaviour
{
    // Start is called before the first frame update
    private Color startColor;


    private void Start()
    {
        startColor = GetComponent<SpriteRenderer>().color;
        ColorLever.SendNewColor += ChangeColor;
    }

    public void ChangeColor(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
    }

}
