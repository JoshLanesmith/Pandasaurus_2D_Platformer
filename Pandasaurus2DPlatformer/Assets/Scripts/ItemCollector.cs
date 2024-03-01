using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ItemCollector : MonoBehaviour
{
    public UnityEvent<string> onButterflyCaptured;

    public bool isBeingCaptured = false;
    public float moveSpeed = 1f;

    private PlayerMovement playerMovement;

    [SerializeField] private Image butterflyFirstJar;
    [SerializeField] private Image butterflySecondjar;
    [SerializeField] private Image butterflyThirdJar;
    [SerializeField] private Image butterflyFourthJar;

    [SerializeField] private AudioSource collectSoundEffect;


    private void Update()
    {
        if (isBeingCaptured)
        {
            RectTransform targetElement = null;
            if (this.CompareTag("Blue"))
            {
                targetElement = butterflyFirstJar.GetComponent<RectTransform>();
                CollectionCount();
            }
            else if (this.CompareTag("Orange"))
            {
                targetElement = butterflySecondjar.GetComponent<RectTransform>();
                CollectionCount();
            }
            else if (this.CompareTag("Purple"))
            {
                targetElement = butterflyThirdJar.GetComponent<RectTransform>();
                CollectionCount();
            }
            else if (this.CompareTag("Magic"))
            {
                targetElement = butterflyFourthJar.GetComponent<RectTransform>();
                CollectionCount();
            }

            void CollectionCount()
            {
                if (targetElement != null)
                {
                    transform.position = Vector3.Lerp(transform.position, targetElement.position, moveSpeed * Time.deltaTime);
                    if (Vector3.Distance(targetElement.position, transform.position) < 2f)
                    {
                        isBeingCaptured = false;
                        Destroy(gameObject);
                        onButterflyCaptured.Invoke(gameObject.tag);
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
