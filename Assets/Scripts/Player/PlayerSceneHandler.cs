using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSceneHandler : MonoBehaviour
{

    [SerializeField]private SceneHandler sh;
    private Transform startPosition;
    CourageSystem courageSystem;
    public GameObject[] enemyCol;
    Rigidbody2D rb;
    PlayerMovement playerMovement;
    bool isDamageable =true;
    SceneHandler sceneHandler;

    

    private void Start() {
        startPosition = GameObject.FindGameObjectWithTag("Start Position").transform;
        this.gameObject.transform.position = startPosition.transform.position;
        courageSystem = GameManager.instance.courageSystem;
        playerMovement = GameManager.instance.playerMovement;
        sceneHandler = GameManager.instance.scheneHandler;
        
    }
    private void Update() {
        enemyCol = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject weaponCol = GameObject.FindGameObjectWithTag("Weapon");
        foreach(GameObject enemy in enemyCol)
        {
            Physics2D.IgnoreCollision(enemy.transform.GetComponent<Collider2D>(),this.gameObject.transform.GetComponent<Collider2D>(),true);
            Physics2D.IgnoreLayerCollision(7,9);
        }
    }
    private void FixedUpdate() 
    {
        
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
        if(c.transform.tag =="Enemy" && isDamageable)
        {
            
            playerMovement.KBCounter = playerMovement.KBTotalTime;
            if(c.transform.position.x <= transform.position.x)
            {
                playerMovement.KnockFromRight = false;
            }
            if(c.transform.position.x >= transform.position.x)
            {
                playerMovement.KnockFromRight = true;
            }
            StartCoroutine(GetHurt());
            if(courageSystem.currentHP <= 0)
            {
                EndGame();
            }
            else{

                courageSystem.RemoveHP(1);
            }
        }
    }

    public void EndGame()
    {
        sh.ResetLevel();
    }

    IEnumerator GetHurt()
    {
        playerMovement.am.SetTrigger("Hurt");
        Time.timeScale = 0.2f;
        yield return new WaitForSeconds(0.05f);
        Time.timeScale = 1f;
        Debug.Log("I got hit");
        // Time.timeScale = 0;
        // yield return new WaitForSeconds(0.2f);
        // Time.timeScale = 1;
        isDamageable = false;
        yield return new WaitForSeconds(playerMovement.KBTotalTime);
        isDamageable = true;

    }

}
