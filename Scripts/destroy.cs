using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    public float lifeTime = 0f;

    private void Start()
    {
        lifeTime = lifeTime + Time.time;
    }
    void Update()
    {
        if(Time.time > lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
