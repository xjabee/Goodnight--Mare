using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPController : MonoBehaviour
{
    public Animator animator;

    public int hpCount = 5;
    
    // Use this for initialization
    void Start ()
    {
        animator = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update ()
    {
        // animator.SetInteger("hpCount", hpCount);

        // if(Input.GetKeyDown(KeyCode.G))
        // {
        //     hpCount++;
        // }

        // if(Input.GetKeyDown(KeyCode.F))
        // {
        //     hpCount--;
        // }
    }
}
