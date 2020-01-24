using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class movimiento : MonoBehaviour
{
    private Vector2 jump;
    private Rigidbody2D rb2d;
    public float speed;
    public float tiempoPillar;
    float timer = 0f;
    public GameObject gameOver;
    public GameObject Antonio3_4;
    public GameObject AntonioPerfil;
    public Image canvasImage;
    public bool derecha = true;
    float halfSpeed;

    public Escondite Escondite;
    public static bool conducto = false;
   

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        halfSpeed = speed / 2;
        
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
        if (Input.GetKey("s") || conducto)
        {
            speed = halfSpeed;
        }
        if (Input.GetKeyUp("s"))
        {
            speed = halfSpeed * 2;
        }
    } 

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("conducto"))
        {
            conducto = true;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo") && !Escondite.escondido)

        {
            timer += Time.deltaTime;
            canvasImage.color = new Color(canvasImage.color.r, canvasImage.color.g, canvasImage.color.b, canvasImage.color.a + 0.03f);
            if(timer >= tiempoPillar)
            {
                gameOver.SetActive(true);
                Invoke("RestartGame", 2);
            }
        }

        else if (collision.CompareTag("Enemigo") && Escondite.escondido)
        {
            timer = 0f;
            canvasImage.color = new Color(canvasImage.color.r, canvasImage.color.g, canvasImage.color.b, 0);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("conducto"))
        {
            conducto = false;
            speed = halfSpeed * 2;
            AntonioPerfil.SetActive(false);
            Antonio3_4.SetActive(true);
        }
        if (collision.CompareTag("Enemigo") && !Escondite.escondido)
        {
            timer = 0f;
            canvasImage.color = new Color(canvasImage.color.r, canvasImage.color.g, canvasImage.color.b, 0);
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
