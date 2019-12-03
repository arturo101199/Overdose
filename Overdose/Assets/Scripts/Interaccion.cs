using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Interaccion : MonoBehaviour
{
    //diálogos
    public string npcTextMessage = "Soy un/n NPC"; //Dialogo
    public string popUpBoxMessage = "Presiona E"; //menasje de la caja de interacción
    public Rect popupBox = new Rect(0.25f, 0.75f, 0.5f, 0.1f); //Tamaño y posición de la caja que aparece para interactuar
    public Rect messageBox = new Rect(0.1f, 0.09f, 0.8f, 0.2f); //Tamaño y posición de la caja de dialogo
    public Transform player; //Antonio
    public float minDistance = 1f; //Distancia para activar la interacción

    private bool inRange = false;
    private bool showText = false;
    private string mensaje;

    void Start()
    {
        //mensaje de error si Antonio no está asignado como player en el inspector
        if (player == null)
        {
            Debug.LogError("Variable 'player' not set up on " + gameObject.name + ". Disabling the associated script.");
            this.enabled = false;
        }
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= minDistance) //Se comprueba la distancia
        {
            //Activar el mensaje de la caja de interacción
            inRange = true;

            if (Input.GetKeyDown("e"))
            {
                showText = !showText;
            }
        }
        else
        {
            //Los textos desaparecen si Antonio se aleja
            inRange = false;
            showText = false;
        }
    }

    void OnGUI()
    {
        if (inRange && !showText)
        {
           
            GUI.Box(new Rect(Screen.width * popupBox.x, Screen.height * popupBox.y, Screen.width * popupBox.width, Screen.height * popupBox.height), popUpBoxMessage);
        }

        if (showText)
        {
            GUI.Box(new Rect(Screen.width * messageBox.x, Screen.height * messageBox.y, Screen.width * messageBox.width, Screen.height * messageBox.height), npcTextMessage);
        }
    }
}
