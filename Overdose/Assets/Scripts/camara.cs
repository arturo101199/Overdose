using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class camara : MonoBehaviour
{
    public float cameraSmoothX;
    public float cameraSmoothY;
    CinemachineFramingTransposer cameraTransposer;
    CinemachineVirtualCamera camera;
    bool desplazando = false;

    float screenXOffset = 0.5f;
    public float tiempoRecuperacionCamara;
   
    // Start is called before the first frame update
    void Awake()
    {
        camera = GetComponent<CinemachineVirtualCamera>();
        cameraTransposer = camera.GetCinemachineComponent<CinemachineFramingTransposer>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            if (desplazando)
            {
                recuperarCamara();
            }
            screenXOffset = Mathf.Clamp(screenXOffset + cameraSmoothX * Time.fixedDeltaTime, 0.3f, 0.7f);
            cameraTransposer.m_ScreenX = screenXOffset;

        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            if (desplazando)
            {
                recuperarCamara();
            }
            screenXOffset = Mathf.Clamp(screenXOffset - cameraSmoothX * Time.fixedDeltaTime, 0.3f, 0.7f);
            cameraTransposer.m_ScreenX = screenXOffset;
        }
        else if (Input.GetKey("w"))
        {
            desplazando = true;
            cameraTransposer.m_ScreenY += 0.02f;
        }
        else if (Input.GetKeyUp("w"))
        {
            recuperarCamara();
            desplazando = false;
            //cameraTransposer.m_ScreenY = 0.5f;
        }
    }

    void recuperarCamara()
    {
        DOTween.To(() => cameraTransposer.m_ScreenY, x => cameraTransposer.m_ScreenY = x, 0.5f, tiempoRecuperacionCamara);
    }
}