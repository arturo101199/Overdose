using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Interaccion : MonoBehaviour
{
    public string personaje;
    public string npcTextMessage = "Soy un NPC"; //Dialogo
    public string popUpBoxMessage = "Presiona E"; //menasje de la caja de interacción

    public bool terminal = false;
    public AudioClip hackear;
    public AudioSource source;
    public Puerta puerta_Hackeable;

    public bool puerta = false;


    void Start()
    {
        if (transform.tag == "Puerta") puerta = true;
        else if (transform.tag == "terminal") terminal = true;
        source = GetComponent<AudioSource>();

    }

    void Update()
    {
        if (gameObject.GetComponent<Puerta>().abierta)
        {
            npcTextMessage = "";
        }
    }
}
