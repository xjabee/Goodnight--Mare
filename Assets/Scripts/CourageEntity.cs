using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourageEntity : MonoBehaviour
{
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, 5 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D c) 
    {
        if(c.transform.tag == "Player")
        {
            Destroy(this.gameObject);
            //add exp /whatver
        }
    }
}
