using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    bool pausado;
    public GameObject pausa;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pausado)
            {
                pausado = !pausado;
                pausa.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                pausado = !pausado;
                pausa.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
}
