using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace DialogueSystem
{
    public class DialogueLine : DialogueBaseClass
    {
        private Text textHolder;

        [Header("Text Options")]
        [SerializeField] private string input;
        [SerializeField] private Color color;
        [SerializeField] private Font font;

        [Header("Time parameters")]
        [SerializeField] private float delay;
        [SerializeField] private float delaySpeaking;


        [Header("Sound")]
        [SerializeField] private AudioClip sound;

        [Header("Character Image")]
        [SerializeField] private Sprite characterSprite;
        [SerializeField] private Image imageHolder;


        private void Awake()
        {
            textHolder = GetComponent<Text>();
            textHolder.text = "";
            imageHolder.sprite = characterSprite;
            imageHolder.preserveAspect = true;
        }


        private void Start()
        {
            StartCoroutine(WriteText(input, textHolder, color, font, delay, sound,delaySpeaking));
        }

    }

}

