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
    CinemachineConfiner cameraConfiner;

    bool desplazando;
    bool techo;

    float screenXOffset = 0.5f;
    public float tiempoRecuperacionCamara;
   
    void Awake()
    {
        camera = GetComponent<CinemachineVirtualCamera>();
        cameraTransposer = camera.GetCinemachineComponent<CinemachineFramingTransposer>();
        cameraConfiner = GetComponent<CinemachineConfiner>();
    }

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            if (desplazando)
            {
                recuperarCamara();
            }
            screenXOffset = Mathf.Clamp(screenXOffset + cameraSmoothX * Time.deltaTime, 0.3f, 0.7f);
            cameraTransposer.m_ScreenX = screenXOffset;

        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            if (desplazando)
            {
                recuperarCamara();
            }
            screenXOffset = Mathf.Clamp(screenXOffset - cameraSmoothX * Time.deltaTime, 0.3f, 0.7f);
            cameraTransposer.m_ScreenX = screenXOffset;
        }
        else if (Input.GetKey("w"))
        {
            desplazando = true;
            if (!techo)
            {
               cameraTransposer.m_ScreenY += cameraSmoothY * Time.deltaTime;
            }

            if (cameraConfiner.CameraWasDisplaced(camera))
            {
                techo = true;
                cameraTransposer.m_ScreenY -= 0.005f;
            }
        }
        else if (Input.GetKeyUp("w"))
        {
            recuperarCamara();
            desplazando = false;
            techo = false;
        }
    }

    void recuperarCamara()
    {
        DOTween.To(() => cameraTransposer.m_ScreenY, x => cameraTransposer.m_ScreenY = x, 0.5f, tiempoRecuperacionCamara);
    }

}