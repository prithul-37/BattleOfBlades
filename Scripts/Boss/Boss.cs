using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int EnemyHealth = 100;
    private int CurrentHealth;

    public Transform player;
    public bool isFlipped = false;

    public EnemyHealthBar EnemyHealthBar;

    public Animator animatior;
    public bool isIvnivcible = false;

    public Transform groundCheck;
    private bool isGrounded;
    [SerializeField] LayerMask groundLayer;
    private float k_GroundedRadius = .2f;
    public float jumpHeight = 20f;
    public Transform tr;

    [Header("Throwing Kunai")]
    public Transform firePoint;
    public GameObject Kunai;



    void Start()
    {
        CurrentHealth = EnemyHealth;
        EnemyHealthBar.setInitialHealth(EnemyHealth);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, k_GroundedRadius, groundLayer);

    }
    public void Damage(int damage)
    {
        if (isIvnivcible)
            return;

        CurrentHealth -= damage;
        EnemyHealthBar.setHealth(CurrentHealth);
        //Debug.Log(CurrentHealth);


        if ((float)CurrentHealth/ (float)EnemyHealth < .40f)
        {
            animatior.SetBool("Enrage",true);
        }

        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }

    }

    

    public void JumpAttack()
    {
        //Debug.Log("Jump Called");

        float distanceFromPlayer = player.position.x - transform.position.x;
        if (isGrounded)
        {

            if (distanceFromPlayer < 0)
                distanceFromPlayer -= 5f;
            else
                distanceFromPlayer += 5f;

            //Debug.Log(new Vector2(distanceFromPlayer, jumpHeight));
            //rb.AddForce(new Vector2(distanceFromPlayer, jumpHeight), ForceMode2D.Impulse);
            tr.position += new Vector3(distanceFromPlayer ,0,0);

        }
    }


    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    public void throwKunai()
    {
        Instantiate(Kunai, firePoint.position, Quaternion.identity);
    }
}
