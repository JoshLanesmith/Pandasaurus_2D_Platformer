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

    private bool swiping = false;

    private void Update()
    {
        swiping = GetComponent<PlayerMovement>().IsSwiping;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry") && swiping)
        {
            CollectItem(ref cherries, ButterflyFirstTextCountText, collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Pineapple") && swiping)
        {
            CollectItem(ref pineapple, ButterflySecondTextCountText, collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Kiwi") && swiping)
        {
            CollectItem(ref kiwi, ButterflyThirdTextCountText, collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Melon") && swiping)
        {
            if (AudioManager.Instance != null) AudioManager.Instance.PlaySFX("Collect");
            Destroy(collision.gameObject);
            cherries++;
            cherriesText.text = "Cherries: " + cherries;
            CollectItem(ref melon, ButterflyFourthTextCountText, collision.gameObject);
        }
    }
    private void CollectItem(ref int counter, TextMeshProUGUI text, GameObject item)
    {
        collectSoundEffect.Play();
        Destroy(item);
        counter++;
        text.text = counter.ToString();
    }


}
