using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slash : MonoBehaviour
{

    public Transform firePoint;
    public GameObject sword_slash_Prefab;
    
    
    private float nextAttackTime;
    private int attackLeft = 0;
    public float coolDown = 4f;
    public PowerUi powerUi;


    public Animator animator;   

    private void Start()
    {
        nextAttackTime = Time.time;
        powerUi.setText(attackLeft);
    }

    // Update is called once per frame
    void Update()
    {
        if(attackLeft>0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.SetTrigger("Shoot");
                attackLeft--;
                powerUi.setText(attackLeft);
            }
        }

        if (nextAttackTime < Time.time)
        {
            if (attackLeft < 3)
            {
                attackLeft++;
                powerUi.setText(attackLeft);
            }
            nextAttackTime = Time.time + coolDown;

        }
        
    }

    private void Shooot()
    {
        
        //creat slash
        Instantiate(sword_slash_Prefab,firePoint.position,firePoint.rotation);
        animator.ResetTrigger("Shoot");

    }


}
