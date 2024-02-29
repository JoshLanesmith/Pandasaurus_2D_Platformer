using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private int blue_butter = 0;
    private int orange_butter = 0;
    private int kiwi = 0;
    private int melon = 0;

    [SerializeField] private TextMeshProUGUI ButterflyFirstTextCountText;
    [SerializeField] private TextMeshProUGUI ButterflySecondTextCountText;
    [SerializeField] private TextMeshProUGUI ButterflyThirdTextCountText;
    [SerializeField] private TextMeshProUGUI ButterflyFourthTextCountText;

    [SerializeField] private AudioSource collectSoundEffect;

    private bool swiping = false;

    private void Update()
    {
        swiping = GetComponent<PlayerMovement>().IsSwiping;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Blue") && swiping)
        {
            CollectItem(ref blue_butter, ButterflyFirstTextCountText, collision.gameObject);
            Debug.Log("Blue butter!");
        }
        else if (collision.gameObject.CompareTag("Orange") && swiping)
        {
            CollectItem(ref orange_butter, ButterflySecondTextCountText, collision.gameObject);
            Debug.Log("Orange butter!");
        }
        else if (collision.gameObject.CompareTag("Kiwi") && swiping)
        {
            CollectItem(ref kiwi, ButterflyThirdTextCountText, collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Melon") && swiping)
        {
            CollectItem(ref melon, ButterflyFourthTextCountText, collision.gameObject);
        }
    }
    private void CollectItem(ref int counter, TextMeshProUGUI text, GameObject item)
    {
        //collectSoundEffect.Play();
        if(AudioManager.Instance != null) AudioManager.Instance.PlaySFX("Collect");
        Destroy(item);
        counter++;
        //text.text = counter.ToString();
    }


}
