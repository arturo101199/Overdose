using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerObjeto : MonoBehaviour
{
    public Inventario inventario;

    public AudioClip taquilla;
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Objeto"))
        {
            if (Input.GetKeyDown("e"))
            {
                if (!Pausa.pausado)
                {
                    if (collision.gameObject.GetComponent<Objeto>().Nombre == "LlaveCompuesto")
                    {
                        source.PlayOneShot(taquilla);
                    }
                    inventario.objetos.Add(collision.gameObject.GetComponent<Objeto>());
                    collision.gameObject.SetActive(false);
                }
            }
        }
    }
}
