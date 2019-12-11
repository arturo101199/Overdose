using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escondite : MonoBehaviour
{
    public bool escondido;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("escondido")) { escondido = true; }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("escondido")) { escondido = false; }
    }
}