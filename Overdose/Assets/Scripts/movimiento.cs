using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    private Vector2 jump;
    private Rigidbody2D rb2d;
    public float speed;
   
    public float jumpForce;
    bool isJumping;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        
    }

    // Use this for initialization
    void FixedUpdate()
    {

        float moverHorizontal = Input.GetAxisRaw ("Horizontal");
        // float moverVertical = Input.GetAxisRaw ("Vertical");
        Vector2 movement = new Vector2(moverHorizontal * speed, 0);//moverVertical*speed);
        rb2d.velocity = movement;
        
        Jump();
        

    }
    void Jump() {
        if (Input.GetKeyDown(KeyCode.Space)&& !isJumping)
        {
            isJumping = true; // variable para saber cuando saltar, la cosa es actualizar cuando haya colliders
            Debug.Log("sida");
            isJumping = true;
            //rb2d.AddForce(new Vector2(0, jumpForce));
            rb2d.velocity = Vector2.up*jumpForce;
;
        }
        else isJumping = false;
    }
}
