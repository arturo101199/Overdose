using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionPerfil : MonoBehaviour
{

    public GameObject antonio3_4;
    Animator animator;
    public movimiento movimiento_;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if(Input.GetKeyUp("s"))
        {
            if(!movimiento.conducto)
                CambiarAntonios();
        }
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            animator.SetBool("Gateando", true);
            if (!movimiento_.derecha)
            {
                movimiento_.derecha = true;
            }
                if(transform.localScale.x < 1)
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        else if (Input.GetAxisRaw("Horizontal") == -1)
        {
            animator.SetBool("Gateando", true);
            if (movimiento_.derecha)
            {
                movimiento_.derecha = false;
            }
            if (transform.localScale.x > -1)
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            animator.SetBool("Gateando", false);
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
        if(!movimiento_.derecha)
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    void CambiarAntonios()
    {
        antonio3_4.SetActive(true);
        gameObject.SetActive(false);
    }
}
