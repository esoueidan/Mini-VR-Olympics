using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PointMarqued : MonoBehaviour
{
    public Text pointsText;  
    private static int points = 0; 

    private void Start()
    {
        if (pointsText != null)
        {
            pointsText.text = "Points: " + points;
        }
        else
        {
            Debug.LogError("Points Text UI element is not assigned.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            points += 1;
            if (pointsText != null)
            {
                pointsText.text = "Points: " + points;
            }
        }
    }
}

