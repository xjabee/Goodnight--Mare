using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSlimeMechanics : MonoBehaviour
{
    Transform player;  
    Rigidbody2D rb;
    // Start is called before the first frame update
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

        if(this.GetComponent<EnemyCombat>().HP == 20)
        {
            transform.localScale = new Vector3(transform.localScale.x/2, transform.localScale.y/2, transform.localScale.z/2);
            Debug.Log("IM BELOW 20 HP");
        }
    }

    IEnumerator Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 10f);
        yield return new WaitForSeconds(0);
    }
}
