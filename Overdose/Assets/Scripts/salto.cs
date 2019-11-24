using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salto : MonoBehaviour
{
    public bool salto_;
    private Rigidbody2D rb2d;
    public int height;
    public LayerMask layer;
    public float radius;
    

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = new Vector2(rb2d.position.x, rb2d.position.y-2);
        salto_ = Physics2D.OverlapCircle(pos,radius,layer);

       // if (salto == true) Debug.Log("choca");
       // else Debug.Log(Physics2D.OverlapCircle(pos,100.0f,layer));

        if (Input.GetKeyDown(KeyCode.Space)&& salto_) {
            rb2d.AddForce(height * Vector2.up, ForceMode2D.Impulse);
        }
        
    }
}
