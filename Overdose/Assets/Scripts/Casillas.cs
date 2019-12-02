using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Casillas : MonoBehaviour
{
    public Image imagen;
    private Objeto _objeto;

   public Objeto Objeto
   {
       get { return _objeto;  }
       set
       {
           _objeto = value;
           if (_objeto == null)
            {
               imagen.enabled = false;
           }
           else
           {
               imagen.sprite = _objeto.Icono;
               imagen.enabled = true;
           }
       }
   }

   private void Update()
   {
        if (imagen == null) imagen = GetComponent<Image>();
    }

}
