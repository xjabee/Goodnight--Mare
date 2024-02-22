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
    [SerializeField] private LayerMask jumpableGround;
    private Rigidbody2D rb;
    private TrailRenderer tr;
    private Collider2D coll;

    private bool isWallJumping;
    private float wallJumpingDirection;
    private float wallJumpingTime = 0.2f;
    private float wallJumpingCounter;
    private float wallJumpingDuration = 0.4f;
    private bool isWallSliding;
    private float wallSlidingSpeed = 2f;
    [SerializeField]private Vector2 wallJumpingPower = new Vector2(20f,16f);

    private Animator am;
    

    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();
        coll = GetComponent<Collider2D>();
        am = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D isGrounded = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0, Vector2.down, 0.1f, jumpableGround);
        RaycastHit2D isSlidingRight = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0, Vector2.right, 0.1f, jumpableGround);
        RaycastHit2D isSlidingLeft = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0, Vector2.left, 0.1f, jumpableGround);
        

        if(isDashing)
        {
            return;
        }
        horizontal = Input.GetAxisRaw("Horizontal");
        am.SetFloat("Speed", Mathf.Abs(horizontal));
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

        WallSide(isGrounded,isSlidingLeft,isSlidingRight);
        WallJump();
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
        if(!isWallJumping)
        {
            
        }

        Flip();
            
    }

    void HitEnemy()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.Z))
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

        if(c.transform.tag =="Enemy")
        {
            SceneManager.LoadScene("New Scene");
        }
    }

    IEnumerator Attack()
    {
        am.SetBool("isAttacking", true);
        attackHitbox.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        am.SetBool("isAttacking", false);
        attackHitbox.SetActive(false);
    }

    private void WallSide(RaycastHit2D isGrounded,RaycastHit2D isSlidingLeft,RaycastHit2D isSlidingRight)
    {
        
        if(isSlidingLeft || isSlidingRight && !isGrounded && horizontal != 0f)
        {
            Debug.Log("I'm WALL SLIDING");
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }

    private void WallJump()
    {

        if(isWallSliding)
        {
            isWallJumping = false;
            wallJumpingDirection = -transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;
            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }
        if(Input.GetKeyDown(KeyCode.Space) && wallJumpingCounter > 0f)
        {
            isWallJumping = true;
           //rb.AddForce(-wallJumpingDirection * wallJumpingPower);
            rb.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            Debug.Log(rb.velocity);
            wallJumpingCounter = 0f;

            // if(transform.localScale.x != wallJumpingDirection)
            // {
            //     isFacingRight = !isFacingRight;
            //     Vector3 LocalScale = transform.localScale;
            //     LocalScale.x *= -1f;
            //     transform.localScale = LocalScale;
            // }
            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }
        

    }

    private void StopWallJumping()
    {
        isWallJumping = false;
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
