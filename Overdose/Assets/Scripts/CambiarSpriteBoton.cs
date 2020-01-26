using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class CambiarSpriteBoton : MonoBehaviour
{

    public Sprite spriteNuevo;
    private Button pb;

    private void OnMouseEnter()
    {
        pb.image.sprite = spriteNuevo;
        Debug.Log("Mouse Enter");
    }
    // Start is called before the first frame update
    void Start()
    {
        pb = GetComponent<Button>();
    }

    private void OnMouseExit()
    {
        Debug.Log("Mouse Exit");
        //Change Image back to default?
    }
}
