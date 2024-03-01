using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Animator am;
    public Transform attackPoint;
    public float attackRange = 1000;
    public LayerMask enemyLayers;
    public float attackSpeed = .4f;
    [SerializeField]private float attackCooldown = .4f;
    float attackCooldownCheck;
    float attackTime;
    bool canAttack = true;
    CourageSystem courageSystem;
    Collider2D[] hitEnemies;


    private void Start() 
    {
        am = GetComponent<Animator>();
        courageSystem = GameManager.instance.courageSystem;
        attackCooldownCheck = attackCooldown;
    }
    private void Update() 
    {
        
        if(attackCooldownCheck <= 0)
        {
            canAttack = true;
        }
        attackCooldownCheck-=Time.deltaTime;
        
        if(!PauseManager.isGamePaused)
        {
            if(Input.GetMouseButtonDown(0) && canAttack)
            { 
                am.SetTrigger("Attack");
                canAttack = false;
                attackCooldownCheck = attackCooldown;
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
        

        if(c.transform.tag == "Courage Entity")
        {
            Destroy(c.gameObject);
            courageSystem.AddCourage(1);
            //add exp /whatver
        }
        
    }
    void CheckAttack()
    {
        hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log(enemy.name);
            enemy.GetComponent<EnemyCombat>().TakeDamage();
        }
    }
}
