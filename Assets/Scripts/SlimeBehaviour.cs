using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class SlimeBehaviour : MonoBehaviour
{

    public int HP = 2;
    int hitcount = 0;
    SpriteRenderer sr;
    // Start is called before the first frame update
    public GameObject babySlime;
    private void Start() 
    {
        sr = GetComponent<SpriteRenderer>();
    }

    
    private void OnTriggerEnter2D(Collider2D c) 
    {
        
        if(c.transform.tag == "Weapon")
        {
            StartCoroutine(GotHit());
            if (HP <= 0)
            {
                if(babySlime == null)
                {
                    Destroy(this.gameObject);
                }
                else
                {
                    SpawnBaby();
                    SpawnBaby();
                    SpawnBaby();
                    Destroy(this.gameObject);
                }
                
                
            }
            else
            {
                HP--;
            }
            
        }
    }

    void SpawnBaby()
    {
        Vector3 randomSpawn = new Vector3( 
                    (Random.Range(this.transform.position.x + 1, this.transform.position.x - 1 ))
                    ,(Random.Range(this.transform.position.y + 1, this.transform.position.y - 1 ))
                    ,(Random.Range(this.transform.position.z + 1, this.transform.position.z - 1 )));

        Instantiate(babySlime, randomSpawn, Quaternion.identity);
        
    }
    IEnumerator GotHit()
    {
        sr.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.white;
    }
}
