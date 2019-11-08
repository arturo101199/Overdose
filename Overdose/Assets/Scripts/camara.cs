using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class camara : MonoBehaviour
{
    public float cameraSmoothX;
    public float cameraSmoothY;
    CinemachineFramingTransposer cameraTransposer;
    CinemachineCameraOffset cameraOffset;

    float screenXOffset = 0.5f;
    float screenYOffset = 0;
    float currentCameraY;
    // Start is called before the first frame update
    void Awake()
    {
        cameraTransposer = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>();
        cameraOffset = GetComponent<CinemachineCameraOffset>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            screenXOffset = Mathf.Clamp(screenXOffset + cameraSmoothX * Time.fixedDeltaTime, 0.3f, 0.7f);
            cameraTransposer.m_ScreenX = screenXOffset;

        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            screenXOffset = Mathf.Clamp(screenXOffset - cameraSmoothX * Time.fixedDeltaTime, 0.3f, 0.7f);
            cameraTransposer.m_ScreenX = screenXOffset;

        }
        else if (Input.GetKey("w"))
        {
            Debug.Log(currentCameraY + " " + transform.position.y);
            if(currentCameraY != transform.position.y)
            {
                currentCameraY = transform.position.y;
                screenYOffset = screenYOffset + cameraSmoothY * Time.fixedDeltaTime;
                cameraOffset.m_Offset = Vector3.up * screenYOffset;
            }
                
        }
    }
}