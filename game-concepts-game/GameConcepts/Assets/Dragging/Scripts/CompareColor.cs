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
    [SerializeField] private TMP_Text timer;
    public float timeLeft = 20f;
    private float _countDownAccumulated;

    private void Start()
    {
        colors = new List<Color>() {Color.red, Color.green, Color.blue};
        score = 0;
        PickNewColor();
       

    }

    private void Update()
    {
        UpdateTimer();
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
    
    private void UpdateTimer()
    {
        _countDownAccumulated += Time.deltaTime;
        
        if (_countDownAccumulated > 0.01f)
        {
            timeLeft -= 0.01f;
            timer.text = timeLeft.ToString("00");
            _countDownAccumulated = 0f;
        }
        if(timeLeft <= 0f)
        {
            timer.text = "GAME OVER";
           
        }
    }
 
}
