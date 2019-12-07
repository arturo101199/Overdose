using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelTransicion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DesactivarTransicion", 2);
    }

    void DesactivarTransicion()
    {
        gameObject.SetActive(false);
    }

}
