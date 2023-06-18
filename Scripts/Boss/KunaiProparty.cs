using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiProparty : MonoBehaviour
{


    private GameObject player;
    private Rigidbody2D rb;
    public float force;

    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized*force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rot);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "Boss")
        {
            Debug.Log(collision.name);
            playerHealth player = collision.GetComponent<playerHealth>();
            if (player != null)
            {
                player.takeDamage(damage);
            }
            Destroy(gameObject);
        }


    }
}
