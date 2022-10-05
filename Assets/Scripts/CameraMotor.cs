using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public GameObject cam;
    public static float cameraSpeed;
    public static float defaultSpeed = 0.5f / 30f;
    public GameObject pauseScreen;
    public float lastFrame;

    public static float passed;
    // Update is called once per frame
    private void Start()
    {
        passed = Time.time;
        cameraSpeed = defaultSpeed;
    }
    void Update()
    {
        if (Time.time - passed > 3f)
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

    public static void Slow()
    {
        cameraSpeed = defaultSpeed;
        passed = Time.time;
    }
}
