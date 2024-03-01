using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSceneHandler : MonoBehaviour
{

    [SerializeField]private SceneHandler sh;
    private Transform startPosition;
    CourageSystem courageSystem;
    private void Start() {
        startPosition = GameObject.FindGameObjectWithTag("Start Position").transform;
        this.gameObject.transform.position = startPosition.transform.position;
        courageSystem = GameManager.instance.courageSystem;
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
            
            courageSystem.RemoveCourage(1);
        }
    }

    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(7,8);
        yield return new WaitForSeconds(2f);
        Physics2D.IgnoreLayerCollision(7,8, false);

    }

}
