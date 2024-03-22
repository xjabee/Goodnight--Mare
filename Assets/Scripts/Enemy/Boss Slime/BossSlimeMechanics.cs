using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSlimeMechanics : MonoBehaviour
{
    Transform player;  
    private int currentHP;
    Rigidbody2D rb;    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.instance.playerTransform;
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("Jump", 0, 10f);
        currentHP = GetComponent<EnemyCombat>().HP;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 5*Time.deltaTime);
        Debug.Log(GetComponent<EnemyCombat>().HP);

        if(GetComponent<EnemyCombat>().HP == 1)
        {
            GameManager.instance.panel.SetActive(true);
            Debug.Log("DID I DIE?");
        }
        if(GetComponent<EnemyCombat>().HP < currentHP)
        {
            if(transform.localScale.x <= 0)
            {     
                transform.localScale = new Vector3(transform.localScale.x+1, transform.localScale.y-1, transform.localScale.z-1);
            }
            if(transform.localScale.x >= 0)
            {
                transform.localScale = new Vector3(transform.localScale.x-1, transform.localScale.y-1, transform.localScale.z-1);
            }
            currentHP = GetComponent<EnemyCombat>().HP;
        }
    }



    IEnumerator Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 10f);
        yield return new WaitForSeconds(0);
    }
}
