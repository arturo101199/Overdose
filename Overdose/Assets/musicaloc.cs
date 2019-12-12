using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicaloc : MonoBehaviour
{
    public BotonInstrucciones BotonInstrucciones;
    private AudioSource source;

    // Update is called once per frame
    void Update()
    {
        if (!BotonInstrucciones.musica) { source.Stop();}
        
    }
}
