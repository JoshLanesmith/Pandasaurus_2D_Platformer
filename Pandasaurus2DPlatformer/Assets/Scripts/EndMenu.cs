using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("1. Main Menu Scene");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Escaping Game...");
    }
}
