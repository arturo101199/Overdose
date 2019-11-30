using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movimiento : MonoBehaviour
{
    private Vector2 jump;
    private Rigidbody2D rb2d;
    public float speed;
    public GameObject gameOver;
   

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
        if (collision.CompareTag("Enemigo"))
        {
            gameOver.SetActive(true);
            Invoke("RestartGame", 2);
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
