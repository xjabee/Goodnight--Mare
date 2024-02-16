using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //temporary move to different class alongside the death handler

public class PlayerMovement : MonoBehaviour
{

     [Header("Player Stats")]
    public float speed = 8f;
    [SerializeField] [Range(2f,16f)] private float jumpPower = 3f;
    [Range(1f,0.01f)] public float attackSpeed = 0.45f;
    private float horizontal;
    
    public GameObject attackHitbox;
    private bool isFacingRight = true;
    [SerializeField]private bool IsGrounded = false;
    private Rigidbody2D rb;
    

    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
        HitEnemy();
    }

    private void FixedUpdate() 
    {
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
            SceneManager.LoadScene("SampleScene");
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


    //temporary, move to a different class

    private void OnTriggerEnter2D(Collider2D c) 
    {
        if(c.transform.tag =="Deathzone")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
