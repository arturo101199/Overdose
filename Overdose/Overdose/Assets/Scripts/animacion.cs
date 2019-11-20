using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animacion : MonoBehaviour
{
    Animator animator;
    bool derecha = true;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Pausa.pausado)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("saltando", true);
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                animator.SetBool("saltando", false);
            }
            if (Input.GetAxisRaw("Horizontal") == 1)
            {
                animator.SetBool("moviendo", true);
                if (!derecha)
                {
                    derecha = true;
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                }
            }
            else if (Input.GetAxisRaw("Horizontal") == -1)
            {
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
