using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonInstrucciones : MonoBehaviour
{
    public bool musica=true;

    public void CambiarEscena()
    {
        musica = !musica;
        SceneManager.LoadScene("scenesOverdose");
    }
}
