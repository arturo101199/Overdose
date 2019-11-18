using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salto : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public int height;
    public LayerMask layer;
    

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 pos = new Vector2(rb2d.position.x, rb2d.position.y-2);
        bool salto = Physics2D.OverlapCircle(pos,2f,layer);

        if (salto == true) Debug.Log("choca");
        else Debug.Log(Physics2D.OverlapCircle(pos,100.0f,layer));

        if (Input.GetKeyDown(KeyCode.Space)&& salto) {
            rb2d.AddForce(height * Vector2.up);
        }
        
    }
}
