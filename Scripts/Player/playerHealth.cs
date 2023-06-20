using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    public int playerMaxHealth = 100;

    private int playerCurrentHealth;

    public playerHealthBar healthBar;
    public Animator animator;

    public GameObject boss;

    private bool isDead = false;
    private float timer;

    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
        healthBar.setMaxHealth(playerMaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == true && timer < Time.time)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }

    public void takeDamage(int damage)
    {
        playerCurrentHealth -= damage;
        healthBar.setHealth(playerCurrentHealth);
        
        if(playerCurrentHealth <=0)
        {
            this.GetComponent<Rigidbody2D>().gravityScale = 0;
            this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            this.GetComponent<CapsuleCollider2D>().enabled = false;
            this.GetComponent<CircleCollider2D>().enabled = false;
            this.GetComponent<characterController>().enabled = false;
            this.GetComponent<playerMovement>().enabled = false;    
            
            animator.SetBool("IsDead", true);
            boss.GetComponent<Animator>().SetBool("PlayerDead",true);

            isDead = true;
            timer = Time.time + 1f;

        }
    }
}
