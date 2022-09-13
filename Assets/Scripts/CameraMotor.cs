using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public GameObject cam;
    public static float cameraSpeed;
    public GameObject pauseScreen;
    public float lastFrame;
    // Update is called once per frame
    private void Start()
    {
        cameraSpeed = 0.5f / 60f;
    }
    void Update()
    {
        if (Time.time > 3f)
        {
            if (!pauseScreen.activeInHierarchy)
            {
                Vector3 movement = new Vector3(0, cameraSpeed, 0);
                cam.transform.position = cam.transform.position + movement;

                /*
                 * Check if a # of seconds has passed then make the speed larger
                 * make # of seconds modular like cam speed
                 * system is simlar to Systems.cs method
                 */
                if (Time.time - lastFrame >= 2f && !pauseScreen.activeInHierarchy)
                {
                    cameraSpeed *= 1.08f;
                    lastFrame = Time.time;
                }
            }
        }
    }
}
