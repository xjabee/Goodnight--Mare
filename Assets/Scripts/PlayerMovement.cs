using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement; //temporary move to different class alongside the death handler

public class PlayerMovement : MonoBehaviour
{

     [Header("Player Stats")]
    public float speed = 12f;
    [SerializeField] [Range(2f,16f)] private float jumpPower = 3f;
    [Range(1f,0.01f)] public float attackSpeed = 0.45f;
    private float horizontal;
    
    private bool canDash = true;
    private bool isDashing;
    [SerializeField] private float dashingPower = 24f;
    [SerializeField] private float dashingTime = 0.2f;
    [SerializeField] private float dashingCooldown = 1f;


    
    public GameObject attackHitbox;
    private bool isFacingRight = true;
    [SerializeField]private bool IsGrounded = false;
    private Rigidbody2D rb;
    private TrailRenderer tr;
    

    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDashing)
        {
            return;
        }
        horizontal = Input.GetAxisRaw("Horizontal");
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
        HitEnemy();

        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    private void FixedUpdate() 
    {
        if(isDashing)
        {
            return;
        }
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        Flip();
    }

    void HitEnemy()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Attack());
        }
    }

    private void Flip()
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnCollisionEnter2D (Collision2D c)
    {
        Debug.Log("Test");
        if(c.transform.tag == "Ground")
        {
            IsGrounded = true;
        }

        if(c.transform.tag =="Enemy")
        {
            SceneManager.LoadScene("New Scene");
        }
    }
    private void OnCollisionExit2D (Collision2D c)
    {
        if(c.transform.tag == "Ground")
        {
            IsGrounded = false;
        }
    }

    IEnumerator Attack()
    {
        attackHitbox.SetActive(true);
        yield return new WaitForSeconds(attackSpeed);
        attackHitbox.SetActive(false);
    }


    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = originalGravity;
        tr.emitting = false;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    
}
