using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//made with help from chatgpt
public class BasketTimer : MonoBehaviour
{
    public Text timerText;  
    public Canvas endCanvas; 
    public float startTime = 60f;  

    private float timeRemaining;

    private void Start()
    {
        timeRemaining = startTime;
        endCanvas.gameObject.SetActive(false);
        UpdateTimerDisplay();
    }

    private void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            ShowEndCanvas();
        }
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0}:{1}", minutes, seconds);
    }

    private void ShowEndCanvas()
    {
        endCanvas.gameObject.SetActive(true);
        timerText.gameObject.SetActive(false);
    }
}