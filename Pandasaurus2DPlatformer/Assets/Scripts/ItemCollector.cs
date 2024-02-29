using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;
    private int pineapple = 0;
    private int kiwi = 0;
    private int melon = 0;

    [SerializeField] private TextMeshProUGUI ButterflyFirstTextCountText;
    [SerializeField] private TextMeshProUGUI ButterflySecondTextCountText;
    [SerializeField] private TextMeshProUGUI ButterflyThirdTextCountText;
    [SerializeField] private TextMeshProUGUI ButterflyFourthTextCountText;

    [SerializeField] private AudioSource collectSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            cherries++;
        }
    }


}
