using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Vector3 localScale;
    // public Slider slider;
    // public Gradient gradient;
    // public Image fill;
    // public void SetHealth(int health){
    //     slider.value = health;
    //     fill.color = gradient.Evaluate(slider.normalizedValue);
    // }

    // public void SetMaxHealth(int health){
    //     slider.maxValue = health;
    //     slider.value = 0;
    //     fill.color = gradient.Evaluate(0f);

    // }
    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthBar();
        
    }
    void UpdateHealthBar(){
        localScale.x = FlamethrowerCooking.currentHits;
        transform.localScale = localScale;
    }
}
