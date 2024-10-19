using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealthBar : MonoBehaviour
{
    public Slider slider;

    public void MaximumHealthIs(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealthTo(int health)
    {
        slider.value = health;
    }
}
