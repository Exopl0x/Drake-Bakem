using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI textbox;
    private void Update()
    {
        textbox.text = score.ToString();
    }
}
