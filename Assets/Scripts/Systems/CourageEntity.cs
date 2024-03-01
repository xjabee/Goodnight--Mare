using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourageEntity : MonoBehaviour
{
    private Transform target;
    CourageSystem courageSystem;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        courageSystem = GameManager.instance.courageSystem;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, 5 * Time.deltaTime);
    }
}
