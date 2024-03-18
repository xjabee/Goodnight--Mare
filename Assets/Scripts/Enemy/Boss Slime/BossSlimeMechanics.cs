using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSlimeMechanics : MonoBehaviour
{
    Transform player;  
    Rigidbody2D rb;    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.instance.playerTransform;
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("Jump", 0, 10f);
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
        
    }

    IEnumerator Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 10f);
        yield return new WaitForSeconds(0);
    }
}
