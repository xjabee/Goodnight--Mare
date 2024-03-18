using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    private Animator am;
    public float timeOnPlatform = 0f;
    // Start is called before the first frame update
    void Start()
    {
        am = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeOnPlatform >= 2)
        {
            am.SetTrigger("Falling");
            timeOnPlatform = 0f;
        }
    }




    private void OnTriggerEnter2D(Collider2D c) 
    {
        if(c.transform.tag == "Player" || c.transform.tag == "Enemy")
        {
            am.SetTrigger("Shake");
        }
    }

    private void OnTriggerStay2D(Collider2D c) 
    {
        if(c.transform.tag == "Player"|| c.transform.tag == "Enemy")
        {
            timeOnPlatform += Time.deltaTime;
        }    
    }
}
