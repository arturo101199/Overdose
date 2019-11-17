using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class AbrirPuerta : MonoBehaviour
{
    bool enPuerta;
    bool enTransicion;
    Vector3 nuevaPosicion;
    PolygonCollider2D nuevoCollider;

    public CinemachineConfiner cameraConfiner;
    public GameObject transicion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            if (!Pausa.pausado)
            {
                if (enPuerta && !enTransicion)
                {
                    transicion.SetActive(true);
                    enTransicion = true;
                    transform.position = nuevaPosicion;
                    cameraConfiner.m_BoundingShape2D = nuevoCollider;
                    Invoke("desactivarTransicion", 2);
                }
            }
            
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Puerta"))
        {
            enPuerta = true;
            nuevaPosicion = collision.gameObject.GetComponent<Puerta>().destino.position;
            nuevoCollider = collision.gameObject.GetComponent<Puerta>().cameraCollider;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        enPuerta = false;
    }

    void desactivarTransicion()
    {
        transicion.SetActive(false);
        enTransicion = false;
    }
}
