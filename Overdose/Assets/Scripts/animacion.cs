using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animacion : MonoBehaviour
{
    Animator animator;

    public salto salto;
    public GameObject antonioPerfil;
    public movimiento movimiento_;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(salto.salto_)
            animator.SetBool("saltando", false);
        if (!Pausa.pausado)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (salto.salto_)
                    animator.SetBool("saltando", true);
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                animator.SetBool("saltando", false);
            }

            if (Input.GetKeyDown("s"))
            {
                if(salto.salto_)
                    CambiarAntonios();
            }


            if (Input.GetAxisRaw("Horizontal") == 1)
            {
                if(salto.salto_)
                    animator.SetBool("moviendo", true);
                if (!movimiento_.derecha)
                {
                    movimiento_.derecha = true;
                }
                if(transform.localScale.x < 1)
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }

            else if (Input.GetAxisRaw("Horizontal") == -1)
            {
                if(salto.salto_)
                    animator.SetBool("moviendo", true);
                if (movimiento_.derecha)
                {
                    movimiento_.derecha = false;
                }
                if(transform.localScale.x > -1)
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }

            else
            {
                animator.SetBool("moviendo", false);
            }
            
            
        }
        
    }
    void OnEnable()
    {
        SetDirection();
    }

    void OnDisable()
    {
        if (transform.localScale.x < 1)
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    void SetDirection()
    {
        if (!movimiento_.derecha)
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
    void CambiarAntonios()
    {
        antonioPerfil.SetActive(true);
        gameObject.SetActive(false);
    }
}
