using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class DoppengangerBehavior : MonoBehaviour
{
    public int HP = 2;
    int hitcount = 0;

    private SpriteRenderer sr;


    private void Start() 
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D c) 
    {
        
        if(c.transform.tag == "Weapon")
        {
            StartCoroutine(GotHit());
            if (HP <= 0)
            {
                Destroy(this.gameObject);
            }
            else
            {
                HP--;
            }
            
        }
    }


    IEnumerator GotHit()
    {
        Color tmp = sr.color;
        tmp.a = 0f;
        sr.color = tmp;
        yield return new WaitForSeconds(0.1f);
        tmp.a = 255f;
        sr.color = tmp;
        yield return new WaitForSeconds(0.1f);
        tmp.a = 0f;
        sr.color = tmp;
        yield return new WaitForSeconds(0.1f);
        tmp.a = 255f;
        sr.color = tmp;
    }
}
