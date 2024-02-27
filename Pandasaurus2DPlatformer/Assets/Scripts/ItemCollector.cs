using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;

    [SerializeField] private TextMeshProUGUI cherriesText;

    [SerializeField] private AudioSource collectSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            cherries++;
            cherriesText.text = "Cherries: " + cherries;
        }
    }
}
