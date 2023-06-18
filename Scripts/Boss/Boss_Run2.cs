using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss_Run2 : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb;
    Boss boss;
    public float speed = 2.5f;
    public float attackRange = 1.2f;

    public float jumpDistance = 10f;

    public float nextAttacckTime;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //nextAttack = Time.time;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        //Debug.Log("currentPos" + rb.position);
        boss = animator.GetComponent<Boss>();
        nextAttacckTime = Time.time + (float)Random.Range(9,13);

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        //Debug.Log("target" + target);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        //Debug.Log("newPos" + newPos);
        rb.MovePosition(newPos);


        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            animator.SetTrigger("Attack");
            
        }

        if (Vector2.Distance(player.position, rb.position) >= jumpDistance || nextAttacckTime > Time.time)
        {
            animator.SetTrigger("Kunai");
            nextAttacckTime = Time.time + (float)Random.Range(9, 13);
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        animator.ResetTrigger("Kunai");

    }


}
