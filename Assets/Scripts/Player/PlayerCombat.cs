using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Animator am;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public float attackSpeed = .4f;
    float attackTime;
    CourageSystem courageSystem;


    private void Start() 
    {
        am = GetComponent<Animator>();
        courageSystem = GameManager.instance.courageSystem;
    }
    private void Update() 
    {
        if(!PauseManager.isGamePaused)
        {
            if(Input.GetMouseButtonDown(0))
            {
            am.SetTrigger("Attack");
            }
        }
        
    }

    void Attack()
    {
        if(Time.time > attackTime)
        {
            attackTime = Time.time + attackSpeed;
            
            CheckAttack();
        }

        Debug.Log("I was triggered");
        

        
    }


    private void OnDrawGizmosSelected() 
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


    private void OnTriggerEnter2D(Collider2D c) 
    {
        if(c.transform.tag == "Enemy")
        {
            c.GetComponent<EnemyCombat>().TakeDamage();
        }

        if(c.transform.tag == "Courage Entity")
        {
            Destroy(c.gameObject);
            courageSystem.AddCourage(1);
            //add exp /whatver
        }
        
    }
    void CheckAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log(enemy.name);
            enemy.GetComponent<EnemyCombat>().TakeDamage();
        }
    }
}
