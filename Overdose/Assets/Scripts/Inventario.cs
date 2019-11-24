using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    [SerializeField]
    List<string> inventario;
    

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Objeto"))
        {
            if (Input.GetKeyDown("e"))
            {
                if (!Pausa.pausado)
                {
                    inventario.Add(collision.gameObject.GetComponent<Objeto>().objeto);
                    Destroy(collision.gameObject);
                }
            }
        }
    }
}
