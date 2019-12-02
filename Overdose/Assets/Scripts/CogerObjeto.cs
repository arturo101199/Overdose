using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerObjeto : MonoBehaviour
{
    public Inventario inventario;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Objeto"))
        {
            if (Input.GetKeyDown("e"))
            {
                if (!Pausa.pausado)
                {
                    inventario.objetos.Add(collision.gameObject.GetComponent<Objeto>());
                    collision.gameObject.SetActive(false);
                }
            }
        }
    }
}
