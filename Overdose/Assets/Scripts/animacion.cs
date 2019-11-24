using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animacion : MonoBehaviour
{
    Animator animator;
    bool derecha = true;
    public salto salto;
    // Start is called before the first frame update
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

            if (Input.GetAxisRaw("Horizontal") == 1)
            {
                if(salto.salto_)
                    animator.SetBool("moviendo", true);
                if (!derecha)
                {
                    derecha = true;
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                }
            }

            else if (Input.GetAxisRaw("Horizontal") == -1)
            {
                if(salto.salto_)
                    animator.SetBool("moviendo", true);
                if (derecha)
                {
                    derecha = false;
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                }
            }

            else
            {
                animator.SetBool("moviendo", false);
            }
            
            
        }
        
    }
}
