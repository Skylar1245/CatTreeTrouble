using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject menu;
    public GameObject scoreDisplay;
    public GameObject pauseButton;
    public GameObject gameOverDisplay;
    public GameObject player;

    public Animator fade;
    private bool over = false;

    private void Start()
    {
        menu.SetActive(false);
    }

    private void Update()
    {
        if(!player.activeInHierarchy && !over)
        {
            GameOver();
            over = true;
        } else if(player.activeInHierarchy && over)
        {
            Switch();
            over = false;
        }
    }
    public void Switch()
    {
        if(menu.activeInHierarchy)
        {
            menu.SetActive(false);
            scoreDisplay.SetActive(true);
            pauseButton.SetActive(true);
        } else
        {
            menu.SetActive(true);
            scoreDisplay.SetActive(false);
            pauseButton.SetActive(false);

        }
    }

    public void GameOver()
    {
        
        menu.SetActive(true);
        scoreDisplay.SetActive(false);
        pauseButton.SetActive(false);
        gameOverDisplay.SetActive(true);

        fade.Play("FadeOut");
    }
}
