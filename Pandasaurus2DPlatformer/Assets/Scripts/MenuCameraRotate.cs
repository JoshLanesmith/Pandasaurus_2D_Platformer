using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCamera : MonoBehaviour
{
    public float totalTime = 5.0f;
    public float startRotationY = -10.0f;
    public float endRotationY = 10.0f;

    private float elapsedTime = 0.0f;
    private bool isIncreasing = true;
    float currentRotationY;

    void Update()
    {
        elapsedTime += Time.deltaTime;

        float t = elapsedTime / totalTime;

        if (isIncreasing)
        {
            currentRotationY = Mathf.Lerp(startRotationY, endRotationY, t);
        }
        else
        {
            currentRotationY = Mathf.Lerp(endRotationY, startRotationY, t);
        }

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, currentRotationY, transform.rotation.eulerAngles.z);

        if (elapsedTime >= totalTime)
        {
            isIncreasing = !isIncreasing;
            elapsedTime = 0.0f;
        }
    }
}
