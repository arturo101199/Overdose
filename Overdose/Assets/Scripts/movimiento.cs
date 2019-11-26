using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    private Vector2 jump;
    private Rigidbody2D rb2d;
    public float speed;
   

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        
    }

    void Update()
    {
        Agacharse();
    }
    // Use this for initialization
    void FixedUpdate()
    {

        float moverHorizontal = Input.GetAxisRaw ("Horizontal");
        // float moverVertical = Input.GetAxisRaw ("Vertical");
        Vector2 movement = new Vector2(moverHorizontal * speed, rb2d.velocity.y);//moverVertical*speed);
        rb2d.velocity = movement;

    }

    void Agacharse()
    {
        if (Input.GetKeyDown("s"))
            speed = speed / 2;
        if (Input.GetKeyUp("s"))
            speed = speed * 2;
    } 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("hola");
    }
}
