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


    private void Start() 
    {
        am = GetComponent<Animator>();
    }
    private void Update() 
    {
        if(Input.GetMouseButtonDown(0))
        {
          am.SetTrigger("Attack");
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