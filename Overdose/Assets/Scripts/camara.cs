using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class camara : MonoBehaviour
{
    public float cameraSmooth;
    public CinemachineVirtualCamera camera;

    float screen = 0.5f;
    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            screen = Mathf.Clamp(screen + cameraSmooth * Time.fixedDeltaTime, 0.3f, 0.8f);
            Mathf.Clamp(screen, 0.3f, 0.8f);
            camera.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenX = screen;

        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            screen = Mathf.Clamp(screen - cameraSmooth * Time.fixedDeltaTime, 0.3f, 0.8f);
            Mathf.Clamp(screen, 0.3f, 0.8f);
            camera.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenX = screen;

        }
    }
}