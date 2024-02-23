using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSceneHandler : MonoBehaviour
{

    [SerializeField]private SceneHandler sh;


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
