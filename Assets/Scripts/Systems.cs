using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Systems : MonoBehaviour
{
    public GameObject cat;
    public GameObject BottomPoint;
    public int score;
    public float lastFrame;
    public Text scoreDisplay;
    public GameObject pauseScreen;

    public Text scoreText;
    public Text coinsText;

    // Update is called once per frame
    void Update()
    {
        if(Time.time - lastFrame >= 0.5f && !pauseScreen.activeInHierarchy)
        {
            score  +=  1;
            scoreDisplay.text = "Score: " + score;
            lastFrame = Time.time;
        }
        scoreText.text = "" + score;
        coinsText.text = "" + Mathf.Floor(score / 10);
    }

    public void Close()
    {
        Application.Quit();
    }

    public void Restart()
    {
        cat.SetActive(true);
        cat.transform.position = new Vector3(BottomPoint.transform.position.x, BottomPoint.transform.position.y + 3, cat.transform.position.z);
    }    
}
