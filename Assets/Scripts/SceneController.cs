using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{ 
    public void ToGame()
        {
            SceneManager.LoadScene("Main");
            SceneManager.UnloadSceneAsync("Title");
        }

    public void ToTitle()
    {
        SceneManager.LoadScene("Title");
        SceneManager.UnloadSceneAsync("Main");
    }
}
