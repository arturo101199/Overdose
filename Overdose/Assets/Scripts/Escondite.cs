using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escondite : MonoBehaviour
{
    public bool escondido;
    public GameObject antonioPerfil;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("escondido") && antonioPerfil.activeSelf) { escondido = true; }
        else if(collision.CompareTag("escondido") && !antonioPerfil.activeSelf)
            escondido = false;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("escondido")) { escondido = false; }
    }
}