using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColorCompare2 : MonoBehaviour
{
    private List<Color> colors;
    private Color currentColor;
    [SerializeField] private TMP_Text counter;
    private int score;
    private float red;
    private float green;
    private float blue;

    public static event Action<String> ColorMatch;
    public static event Action<String> ColorFail;

    private void Start()
    {
        colors = new List<Color>() {Color.red, Color.green, Color.blue};
        score = 0;
        PickNewColor();
        Timer.TimeEnded += GameOver;

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //ColorCheck(col.gameObject.GetComponent<SpriteRenderer>().color);
        Debug.Log("Hit!!!");
        if (ColorCheck(col.gameObject.GetComponent<SpriteRenderer>().color))
        {
            Debug.Log("YAY");
            PickNewColor();
            score++;
            counter.text = score.ToString();
        }
        else
        {
            Debug.Log("Something is broken...");
        }
    }

    private bool ColorCheck(Color color)
    {
        bool match = false;
        if ((red - 0.1f <= color.r && color.r <= red + 0.1f))
        {
            Debug.Log("Red - YAY");
            match = true;
            ColorMatch?.Invoke("RedLight");
        }
        else
        {
            ColorFail?.Invoke("RedLight");
            Debug.Log("Red" + color.r  +" " + red);
            match = false;
        }
       
        if (blue - 0.1f <= color.b && color.b <= blue + 0.1f)
        {
            Debug.Log("Blue - YAY");
            match = true;
            ColorMatch?.Invoke("BlueLight");
        }
        else
        {
            ColorFail?.Invoke("BlueLight");
            Debug.Log("Blue" + color.b +" " + blue);
            match = false;
            
        }
        if (green - 0.1f <= color.g && color.g <= green + 0.1f)
        {
            Debug.Log("Green - YAY");
            match = true;
            ColorMatch?.Invoke("GreenLight");
        }
        else
        {
            ColorFail?.Invoke("GreenLight");
            Debug.Log("Green" + color.g  +" " + green);
            match = false;
        }

    
        return match;
    }
    private void PickNewColor()
    {
        ColorFail?.Invoke("RedLight");
        ColorFail?.Invoke("BlueLight");
        ColorFail?.Invoke("GreenLight");
        red = Random.Range(0f, 1f);
        green = Random.Range(0f, 1f);
        blue = Random.Range(0f, 1f);
        // red = 1f;
        // green = 0f;
        // blue = 0f;
        print(red+" "+ blue+" " +green);
        currentColor = new Color(red, green, blue,1f);
        //currentColor = Color.red;
        GetComponent<SpriteRenderer>().color = currentColor;
       // print("currentColor" + GetComponent<SpriteRenderer>().color);
        
    }

    private void GameOver()
    {
        GetComponent<SpriteRenderer>().color = Color.black;
        
    }
    
 
}