using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash_Proparty : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public int damage = 10;

    public Transform currentPosition;
    private float start;
    private float lifetime = 10f;

    public GameObject ImpactEffectPrefab;


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        start = currentPosition.position.x;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.name != "player")
        {
            Debug.Log(collision.name);
            Boss boss = collision.GetComponent<Boss>();
            if(boss != null)
            {
                boss.Damage(damage);
            }
            Destroy(gameObject);
            Instantiate(ImpactEffectPrefab, new Vector3(transform.position.x +.8f, transform.position.y, transform.position.z-3f), transform.rotation);
        }
        
        
    }

    private void Update()
    {
        if(Mathf.Abs(start - currentPosition.position.x) > lifetime)
        {
            Destroy(gameObject);
        }

        
    }


}
