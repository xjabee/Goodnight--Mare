using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VialHandler : MonoBehaviour
{
    public Animator animator;

    public int vialMeter = 0;
    public bool reFill = false;
    
    // Use this for initialization
    void Start ()
    {
        animator = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update ()
    {
        // animator.SetInteger("vialMeter", vialMeter);

        // if (vialMeter == 3 && Input.GetKey(KeyCode.E))
        // {
        //     animator.SetInteger("Vial0", 0);
        // }

        // if(Input.GetKeyDown(KeyCode.G))
        // {
        //     vialMeter++;
        // }
    }
}
