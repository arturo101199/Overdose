using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class AbrirPuerta : MonoBehaviour
{
    bool enPuerta;
    bool enTransicion;
    bool abierta;

    Vector3 nuevaPosicion;
    GameObject nuevaCamara;
    Puerta puertaQueAbre;
    Puerta puertaActual;

    public Inventario inventario;

    public GameObject actualCamera;
    public GameObject transicion;

    public AudioClip clip;

    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ComprobarPuerta();
    }

    void ComprobarPuerta()
    {
        if (Input.GetKeyDown("e"))
        {
            if (!Pausa.pausado)
            {
                if (enPuerta && !enTransicion && puertaActual.abierta)
                {
                    Abrir();
                }
                else if (enPuerta && !enTransicion && !puertaActual.abierta)
                {
                    if (inventario.objetos.Contains(puertaActual.llave))
                    {
                        Abrir();
                        inventario.objetos.Remove(puertaActual.llave);
                        puertaActual.abierta = true;
                    }
                }
            }

        }
    }

    void Abrir()
    {
        transicion.SetActive(true);
        enTransicion = true;
        MoverCamara();
        transform.position = puertaActual.destino.position;
        if (puertaActual.puertaQueAbre != null)
        {
            puertaActual.puertaQueAbre.abierta = true;
        }
        source.PlayOneShot(clip);
        Invoke("DesactivarTransicion", 2);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Puerta"))
        {
            enPuerta = true;
            puertaActual = collision.gameObject.GetComponent<Puerta>();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        enPuerta = false;
    }

    void DesactivarTransicion()
    {
        transicion.SetActive(false);
        enTransicion = false;
    }

    void MoverCamara()
    {
        actualCamera.SetActive(false);
        puertaActual.camera.SetActive(true);
        actualCamera = puertaActual.camera;
    }

    
}
