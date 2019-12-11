using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Interaccion : MonoBehaviour
{
    //diálogos
    public string npcTextMessage = "Soy un NPC"; //Dialogo
    public string popUpBoxMessage = "Presiona E"; //menasje de la caja de interacción
    public Rect popupBox = new Rect(0.25f, 0.75f, 0.5f, 0.1f); //Tamaño y posición de la caja que aparece para interactuar
    public Rect messageBox = new Rect(0.1f, 0.09f, 0.8f, 0.2f); //Tamaño y posición de la caja de dialogo
    public Transform player; //Antonio
    public float minDistance = 1f; //Distancia para activar la interacción

    private bool inRange = false;
    private bool showText = false;

    public bool terminal;
    public AudioClip hackear;
    private AudioSource source;
    public Puerta puerta_Hackeable;

    public bool puerta;

    GUIStyle style;

    void Start()
    {

        source = GetComponent<AudioSource>();

        style = new GUIStyle("button");
        style.alignment = TextAnchor.MiddleCenter;

        //mensaje de error si Antonio no está asignado como player en el inspector
        if (player == null)
        {
            Debug.LogError("Variable 'player' not set up on " + gameObject.name + ". Disabling the associated script.");
            this.enabled = false;
        }
    }

    void Update()
    {
        if (Math.Abs(transform.position.x - player.position.x) <= minDistance
            && Math.Abs(transform.position.y - player.position.y) <= 10) //Se comprueba la distancia
        {
            //Activar el mensaje de la caja de interacción
            inRange = true;

            if (Input.GetKeyDown("e"))
            {
                if (terminal & !showText)
                {
                    source.Stop();
                    source.PlayOneShot(hackear);
                    puerta_Hackeable.abierta = true;
                }
                showText = !showText;
            }
        }
        else
        {
            //Los textos desaparecen si Antonio se aleja
            if (terminal) source.Stop();
            inRange = false;
            showText = false;
            
        }
    }

    void OnGUI()
    {
        if (inRange && !showText)
        {
           if (!puerta) GUI.Box(new Rect(Screen.width * popupBox.x, Screen.height * popupBox.y, Screen.width * popupBox.width, Screen.height * popupBox.height), popUpBoxMessage, style);
        }

        if (showText && npcTextMessage != "")
        {
            if (!puerta || (puerta && !transform.gameObject.GetComponent<Puerta>().abierta)) GUI.Box(new Rect(Screen.width * messageBox.x, Screen.height * messageBox.y, Screen.width * messageBox.width, Screen.height * messageBox.height), npcTextMessage, style);
        }
    }
}
