using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ItemCollector : MonoBehaviour
{
    private bool isBeingCaptured = false;
    public float moveSpeed = 1f;

    private int butterflyFirstCount = 0;
    private int butterflySecondCount = 0;
    private int butterflyThirdCount = 0;
    private int butterflyFourthCount = 0;

    private PlayerMovement playerMovement;

    [SerializeField] private Image butterflyFirstJar;
    [SerializeField] private Image butterflySecondjar;
    [SerializeField] private Image butterflyThirdJar;
    [SerializeField] private Image butterflyFourthJar;
    [SerializeField] private TextMeshProUGUI butterflyFirstText;
    [SerializeField] private TextMeshProUGUI butterflySecondText;
    [SerializeField] private TextMeshProUGUI butterflyThridText;
    [SerializeField] private TextMeshProUGUI butterflyFourthText;
    [SerializeField] private AudioSource collectSoundEffect;

    private void Update()
    {
        if (isBeingCaptured)
        {
            RectTransform targetElement = null;
            if (this.CompareTag("Blue"))
            {
                targetElement = butterflyFirstJar.GetComponent<RectTransform>();
                CollectionCount(butterflyFirstText, butterflyFirstCount);
            }
            else if (this.CompareTag("Orange"))
            {
                targetElement = butterflySecondjar.GetComponent<RectTransform>();
                CollectionCount(butterflySecondText, butterflySecondCount);
            }
            else if (this.CompareTag("Purple"))
            {
                targetElement = butterflyThirdJar.GetComponent<RectTransform>();
                CollectionCount(butterflyThridText, butterflyThirdCount);
            }
            else if (this.CompareTag("Magic"))
            {
                targetElement = butterflyFourthJar.GetComponent<RectTransform>();
                CollectionCount(butterflyFourthText, butterflyFourthCount);
            }

            void CollectionCount(TextMeshProUGUI targetTextUI, int currentCount)
            {
                if (targetElement != null)
                {
                    transform.position = Vector3.Lerp(transform.position, targetElement.position, moveSpeed * Time.deltaTime);
                    if (Vector3.Distance(targetElement.position, transform.position) < 2f)
                    {
                        isBeingCaptured = false;
                        Destroy(gameObject);
                        currentCount++;
                        targetTextUI.text = currentCount.ToString();

                    }
                    // Common movement logic for all items
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerMovement = collision.gameObject.GetComponent<PlayerMovement>();

            if (playerMovement != null && playerMovement.IsSwiping)
            {
                isBeingCaptured = true;
                collectSoundEffect.Play();
                if (AudioManager.Instance != null) AudioManager.Instance.PlaySFX("Collect");
            }
        }
    }
}
