using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class AbrirPuerta : MonoBehaviour
{
    bool enPuerta;
    bool enTransicion;
    Vector3 nuevaPosicion;
    GameObject nuevaCamara;
    Puerta puertaQueAbre;

    public CinemachineConfiner cameraConfiner;
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

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Puerta"))
        {
            enPuerta = collision.gameObject.GetComponent<Puerta>().abierta;
            nuevaPosicion = collision.gameObject.GetComponent<Puerta>().destino.position;
            nuevaCamara = collision.gameObject.GetComponent<Puerta>().camera;
            puertaQueAbre = collision.gameObject.GetComponent<Puerta>().puertaQueAbre;
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
        nuevaCamara.SetActive(true);
        actualCamera = nuevaCamara;
    }

    void ComprobarPuerta()
    {
        if (Input.GetKeyDown("e"))
        {
            if (!Pausa.pausado)
            {
                if (enPuerta && !enTransicion)
                {
                    transicion.SetActive(true);
                    enTransicion = true;
                    MoverCamara();
                    transform.position = nuevaPosicion;
                    if (puertaQueAbre != null)
                    {
                        puertaQueAbre.abierta = true;
                    }
                    source.PlayOneShot(clip);
                    Invoke("DesactivarTransicion", 2);
                }
            }

        }
    }
}
