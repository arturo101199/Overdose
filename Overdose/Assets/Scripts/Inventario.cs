using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public List<Objeto> objetos;
    public Transform huecos;
    public Casillas[] casillas;

    private void Update()
    {
        if (huecos != null)
        { casillas = huecos.GetComponentsInChildren<Casillas>(); }

        ActualizarInventario();
    }

    private void ActualizarInventario()
    {
        int i = 0;
        for (; i < objetos.Count && i < casillas.Length; i++)
        {
            casillas[i].Objeto = objetos[i];
        }
        for (; i < casillas.Length; i++)
        {
            casillas[i].Objeto = null;
        }

    }
}
