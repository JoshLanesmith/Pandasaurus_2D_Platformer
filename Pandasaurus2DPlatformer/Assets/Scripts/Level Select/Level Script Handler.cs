using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LevelSelector : MonoBehaviour
{

    public void StartLevel1()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void StartLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void StartLevel3()
    {
        SceneManager.LoadScene("Level 3");
    }
    public void StartLevel4()
        {
            SceneManager.LoadScene("Level 4");
        }
    public void StartLevel5()
        {
            SceneManager.LoadScene("Level 5");
        }

}