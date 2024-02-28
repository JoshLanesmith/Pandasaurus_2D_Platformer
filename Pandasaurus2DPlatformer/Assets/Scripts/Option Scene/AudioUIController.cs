using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioUIController : MonoBehaviour
{
    public Canvas audioControl;

    private bool isMenuActive;

    // Start is called before the first frame update
    void Start()
    {
        audioControl.enabled = false;
        isMenuActive = audioControl.enabled;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    public void ToggleMenu()
    {
        isMenuActive = !isMenuActive;
        audioControl.enabled = isMenuActive;

        Time.timeScale = isMenuActive ? 0f : 1f;
    }
}
