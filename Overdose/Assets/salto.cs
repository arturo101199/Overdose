using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salto : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public int height;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool salto = Input.GetKeyDown(KeyCode.Space);
        if (salto) {
            rb2d.AddForce(height * Vector2.up);
        }
        
    }
}
