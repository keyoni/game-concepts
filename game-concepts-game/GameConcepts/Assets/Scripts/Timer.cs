using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private TMP_Text timerUI;
    [SerializeField] float timeLeft = 20f;
    private float _countDownAccumulated;
    private bool timeEnd = false;

    public static event Action TimeEnded;
    // Start is called before the first frame update
    void Start()
    {
        timerUI = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
     if(!timeEnd)
        UpdateTimer();
        
    }
    private void UpdateTimer()
    {
        _countDownAccumulated += Time.deltaTime;
        
        if (_countDownAccumulated > 0.01f)
        {
            timeLeft -= 0.01f;
            timerUI.text = timeLeft.ToString("00");
            _countDownAccumulated = 0f;
        }
        if(timeLeft <= 0f)
        {
            timeEnd = true;
            timerUI.text = "GAME OVER"; 
            TimeEnded?.Invoke();
        }
    }
}
