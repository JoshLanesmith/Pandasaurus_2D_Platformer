using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioUIController : MonoBehaviour
{
    public Canvas audioControl;

    private bool isMenuActive;

    // Start is called before the first frame update
    void Start()
    {
        audioControl.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (sceneIndex != 0)
            {
                ToggleMenu();
            }
            else
            {
                isMenuActive = audioControl.enabled;
                if (isMenuActive)
                {
                    ToggleMenu();
                }
            }
        }


    }

    public void ToggleMenu()
    {
        isMenuActive = audioControl.enabled;

        if (isMenuActive)
        {
            audioControl.enabled = false;
        }
        else
        {
            audioControl.enabled = true;
        }

        Time.timeScale = isMenuActive ? 1f : 0f;

    }
}
