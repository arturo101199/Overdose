using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionPerfil : MonoBehaviour
{
    bool derecha = true;

    public GameObject antonio3_4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp("s"))
        {
            CambiarAntonios();
        }
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            if (!derecha)
            {
                derecha = true;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }

        else if (Input.GetAxisRaw("Horizontal") == -1)
        {
            if (derecha)
            {
                derecha = false;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
    }

    void CambiarAntonios()
    {
        antonio3_4.SetActive(true);
        gameObject.SetActive(false);
    }
}
