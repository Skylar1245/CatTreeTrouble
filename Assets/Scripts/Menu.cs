using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject me;

    public GameObject scoreDisplay;
    public GameObject pauseButton;

    private void Start()
    {
        me.SetActive(false);
    }
    public void Switch()
    {
        if(me.activeInHierarchy)
        {
            me.SetActive(false);
            scoreDisplay.SetActive(true);
            pauseButton.SetActive(true);
        } else
        {
            me.SetActive(true);
            scoreDisplay.SetActive(false);
            pauseButton.SetActive(false);

        }
    }
}
