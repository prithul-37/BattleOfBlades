using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditScene : MonoBehaviour
{
    private float timer;
    public GameObject go;

    void Start()
    {
        timer = Time.time + 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < Time.time)
        {
            go.SetActive(true);
            this.gameObject.SetActive(false);
            
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit(); 
    }
}
