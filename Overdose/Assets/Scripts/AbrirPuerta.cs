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
                    source.PlayOneShot(clip);
                    Invoke("DesactivarTransicion", 2);
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
            nuevaCamara = collision.gameObject.GetComponent<Puerta>().camera;
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
}
