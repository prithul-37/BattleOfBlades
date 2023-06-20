using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public characterController controller;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    public Animator animatior;



    // Start is called before the first frame update
    void Start()
    {
        
    }

   
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animatior.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animatior.SetBool("IsJump", true);
            //Debug.Log("IsJump : True");
        }
    }

    public void OnLanding()
    {
        animatior.SetBool("IsJump", false);
        //Debug.Log("IsJump : false");
    }

    private void FixedUpdate()
    {
        //Debug.Log(horizontalMove * Time.fixedDeltaTime);
        controller.Move(horizontalMove * Time.fixedDeltaTime,false,jump);
        jump = false;
        
    }
}
