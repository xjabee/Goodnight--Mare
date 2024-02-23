using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlimeBehavior : MonoBehaviour
{

    public int HP = 2;
    int hitcount = 0;
    public float jumpPower = 5;
    public float jumpFrequency = 2f;
    SpriteRenderer sr;
    // Start is called before the first frame update
    public GameObject babySlime;
    Rigidbody2D rb;
    private void Start() 
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("Bounce", 0f, jumpFrequency);
    }

    IEnumerator Bounce()
    {
        rb.AddForce(new Vector2(rb.velocity.x, jumpPower));
        yield return new WaitForSeconds(1f);
    }

    

    public void SpawnBaby()
    {
        Vector3 randomSpawn = new Vector3( 
                    (Random.Range(this.transform.position.x + 1, this.transform.position.x - 1 ))
                    ,(Random.Range(this.transform.position.y + 1, this.transform.position.y - 1 ))
                    ,(Random.Range(this.transform.position.z + 1, this.transform.position.z - 1 )));

        Instantiate(babySlime, randomSpawn, Quaternion.identity);
        Instantiate(babySlime, randomSpawn, Quaternion.identity);
        Instantiate(babySlime, randomSpawn, Quaternion.identity);
        
    }
    
}
