using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ParalaxEffect : MonoBehaviour
{
    
    private float Length,startpos;
    public GameObject cam;
    public float parallaxEffect;


    void Start()
    {
        startpos = transform.position.x;
        Length = GetComponent<SpriteRenderer>().bounds.size.x;

    }

    
    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos+dist,transform.position.y, transform.position.z);

        if (temp > startpos + Length) startpos += Length;
        else if(temp < startpos - Length) startpos -= Length;
        

    }
}
