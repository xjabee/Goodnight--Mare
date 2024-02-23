using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyCombat : MonoBehaviour
{


    private SpriteRenderer sr;
    private SlimeBehavior sb;
    private Rigidbody2D rb;

    public int HP = 3;
    [SerializeField] private float knockbackStr = 5f, delay = 0.15f;
    Vector3 direction = new Vector3(1, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        sb = GetComponent<SlimeBehavior>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    public void TakeDamage()
    {
        HP--;

        StartCoroutine(GotHit());

        //flicker animation
        if(HP<= 0)
        {
            KillEnemy();
        }

    }

    void KillEnemy()
    {
        
        if(sb == null)
        {
            return;
        }
        else
        {
            if(sb.babySlime == null)
            {
                Destroy(this.gameObject);
            }
            sb.SpawnBaby();
        }
        
        
        Destroy(this.gameObject);
    }

    IEnumerator GotHit()
    {
        sr.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.green;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.green;
    }
}
