using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(player.position.x, player.position.y - 2, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(player.position.x, player.position.y + 2, transform.position.z);
        }
    }
}
