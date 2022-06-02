using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class CompareColor : MonoBehaviour
{
    private List<Color> colors;
    private Color currentColor;
    [SerializeField] private TMP_Text counter;
    private int score;


    private void Start()
    {
        colors = new List<Color>() {Color.red, Color.green, Color.blue};
        score = 0;
        PickNewColor();
        Timer.TimeEnded += GameOver;

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Hit!!!");
        if (col.gameObject.GetComponent<SpriteRenderer>().color.Equals(this.GetComponent<SpriteRenderer>().color))
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

    private void PickNewColor()
    {
        int index = Random.Range(0, colors.Count);
        currentColor = colors[index].Equals(currentColor) ? colors[Random.Range(0, colors.Count)] : colors[index];
        GetComponent<SpriteRenderer>().color = currentColor;
        
    }

    private void GameOver()
    {
        GetComponent<SpriteRenderer>().color = Color.black;
    }
    
 
}
