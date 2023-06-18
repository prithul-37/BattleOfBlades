using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public int EnemyHealth = 100;
    private int CurrentHealth;

    public EnemyHealthBar EnemyHealthBar;

    void Start()
    {
        CurrentHealth = EnemyHealth;
        EnemyHealthBar.setInitialHealth(EnemyHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Damage(int damage)
    {
        CurrentHealth -= damage;
        EnemyHealthBar.setHealth(CurrentHealth);
        //Debug.Log(CurrentHealth);

        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }

    }
}
