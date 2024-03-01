using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{

    SceneHandler sceneHandler;

    private void Start() {
        sceneHandler = GameManager.instance.scheneHandler;
    }

    private void OnTriggerEnter2D(Collider2D c) 
    {
        if(c.transform.tag =="Player")
        {
            sceneHandler.ResetLevel();
        }
        if(c.transform.tag =="Enemy")
        {
            Destroy(c.gameObject);
        }
    }
}
