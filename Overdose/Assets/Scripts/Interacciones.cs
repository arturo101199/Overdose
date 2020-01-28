using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interacciones : MonoBehaviour
{
    private bool inRange;
    private bool showText;
    private bool unTerminal;
    private Interaccion objeto;

    public GameObject dBox;
    public Text dText;
    public Text dChar;

    public GameObject puBox;
    public Text puText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Interaccion>())
        {
            inRange = true;
            objeto = collision.gameObject.GetComponent<Interaccion>();

            if (Input.GetKeyDown("e"))
            {
                if (objeto.terminal)
                {
                    objeto.source.Stop();
                    objeto.source.PlayOneShot(objeto.hackear);
                    objeto.puerta_Hackeable.abierta = true;
                }
                showText = !showText;
            }
        }
        /*else
        {
            //Los textos desaparecen si Antonio se aleja
            if (objeto.terminal) objeto.source.Stop();
            inRange = false;
            showText = false;
       
        }*/
       

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Interaccion>())
        {
            objeto = collision.gameObject.GetComponent<Interaccion>();
            if (objeto.terminal)
            {
                objeto.source.Stop();
                objeto.terminal = false;
                objeto.popUpBoxMessage = "";
            }
            inRange = false;
            showText = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        if (inRange && !showText && objeto.popUpBoxMessage != "")
        {

                puBox.SetActive(true);
                puText.text = objeto.popUpBoxMessage;
                dBox.SetActive(false);
        }

        else if (showText && objeto.npcTextMessage != "")
        {
            
            if (!objeto.puerta || (objeto.puerta && !objeto.gameObject.GetComponent<Puerta>().abierta))
            {
                dBox.SetActive(true);
                dText.text = objeto.npcTextMessage;
                dChar.text = objeto.personaje;
                puBox.SetActive(false);
            }
        }
        else
        {
            dBox.SetActive(false);
            puBox.SetActive(false);
        }
    }
}
