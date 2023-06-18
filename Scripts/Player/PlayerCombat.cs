using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 1f;
    public LayerMask enemyLayers;
    public int damage = 10;

    public float AttackRate = 2f;
    private float nextAttackTime = 0f;

    public GameObject player;
    public int charge = 20;

    public EnergyBarPlayer energyBar;
    public energyRay energyRay;

    private void Start()
    {
       energyBar.setMaxEnergy(energyRay.maxCharge);
    }

    // Update is called once per frame
    void Update()
    {    

        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                nextAttackTime = Time.time + 1f/AttackRate;
            }
        }
        
    }

    void Attack()   
    {
        //play attack anime
        animator.SetTrigger("Attack");


    }

    public void detectAndDamage()
    {
        //detect enemy 
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //damage enemy

        foreach (Collider2D enemy in hitEnemies)
        {
            //Debug.Log("We hit" + enemy.name);
            enemy.GetComponent<Boss>().Damage(damage);
            player.GetComponent<energyRay>().incCharge(charge);


        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position,attackRange);  
    }
}
