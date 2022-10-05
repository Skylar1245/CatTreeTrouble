using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Systems : MonoBehaviour
{
    public GameObject cat;
    public Camera cam;
    public GameObject BottomPoint;
    public static int score;
    public static int coins;
    public float lastFrame;
    public Text scoreDisplay;
    public GameObject pauseScreen;

    public Text scoreText;
    public Text coinsText;

    private readonly float[] start = { 0, 0, 0 };
    private readonly float[] startCam = { 0, 0, 0 };

    // Update is called once per frame
    private void Start()
    {
        start[0] = cat.transform.position.x;
        start[1] = cat.transform.position.y;
        start[2] = cat.transform.position.z;

        startCam[0] = cam.transform.position.x;
        startCam[1] = cam.transform.position.y;
        startCam[2] = cam.transform.position.z;
    }
    void Update()
    {
        if(Time.time - lastFrame >= 0.5f && !pauseScreen.activeInHierarchy)
        {
            score  +=  1;
            scoreDisplay.text = "Score: " + score;
            lastFrame = Time.time;
        }
        scoreText.text = "" + score;
        coins = (int)Mathf.Floor(score / 10);
        coinsText.text = "" + coins;
    }

    public void Close()
    {
        SaveData.Save();
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene("Main");
        CameraMotor.Slow();
        SaveData.Save();
        score = 0;
    }    
}
