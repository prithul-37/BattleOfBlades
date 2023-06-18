using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider healthBar;

    public void setInitialHealth(int health)
    {
        Debug.Log(health);

        healthBar.maxValue = health;
        healthBar.value = health;
        
    }

    public void setHealth(int health)
    {
        healthBar.value = health;
    }
}
