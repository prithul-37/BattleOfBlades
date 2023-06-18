using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBarPlayer : MonoBehaviour
{
    public Slider slider;


    public void setMaxEnergy(int energy)
    {
        slider.maxValue = energy;   
        slider.value = 0;
    }

    public void setEnergy(int energy)
    {
        slider.value = energy;
    }
}
