using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D c) 
    {
        if(c.transform.tag =="Player")
        {
            SceneManager.LoadScene("New Scene");
        }
        if(c.transform.tag =="Enemy")
        {
            Destroy(c.gameObject);
        }
    }
}
