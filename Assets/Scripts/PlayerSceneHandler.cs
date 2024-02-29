using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSceneHandler : MonoBehaviour
{

    [SerializeField]private SceneHandler sh;
    private Transform startPosition;

    private void Start() {
        startPosition = GameObject.FindGameObjectWithTag("Start Position").transform;
        this.gameObject.transform.position = startPosition.transform.position;
    }


    private void NextLevel()
    {
        sh.NextLevel();
    }

    private void OnTriggerEnter2D(Collider2D c) 
    {
        if(c.transform.tag == "End Zone")
        {
            NextLevel();
        }
    }

    private void OnCollisionEnter2D (Collision2D c)
    {

        if(c.transform.tag =="Enemy")
        {
            sh.ResetLevel();

        }
    }

}
