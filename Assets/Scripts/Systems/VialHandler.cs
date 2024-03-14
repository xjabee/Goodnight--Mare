using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VialHandler : MonoBehaviour
{
    Animator animator;

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
        if (vialMeter == 0)
        {
            animator.SetInteger("Vial0", 0);
        }
        else if(vialMeter == 1)
        {
            animator.SetInteger("Vial1", 1);
        }
        else if(vialMeter == 2)
        {
            animator.SetInteger("Vial2", 2);
        }
        else if(vialMeter == 3)
        {
            animator.SetInteger("Vial1", 3);
        }
        else
        {
            return;
        }

        if (vialMeter == 3 && Input.GetKey(KeyCode.E))
        {
            animator.SetInteger("Vial0", 0);
        }

    }
}
