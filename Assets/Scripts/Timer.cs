using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerTextBox;
    float timer;

    void Update()
    {
        timer += Time.deltaTime; 
        int conversion = (int)timer;
        timerTextBox.text = conversion.ToString();
    }
}
