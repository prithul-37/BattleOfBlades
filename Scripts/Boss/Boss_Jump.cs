using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Jump : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb;
    public float speed = 1.0f;
    public float jumpHeight = 10f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        float distanceFromPlayer = player.position.x - animator.transform.position.x;
        rb.AddForce(new Vector2(distanceFromPlayer, jumpHeight), ForceMode2D.Impulse);

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        


    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Jump");
    }

    
}
