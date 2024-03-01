using TMPro;
using UnityEngine;

public class JarManager : MonoBehaviour
{
    private int butterflyFirstCount = 0;
    private int butterflySecondCount = 0;
    private int butterflyThirdCount = 0;
    private int butterflyFourthCount = 0;
    [SerializeField] private TextMeshProUGUI butterflyFirstText;
    [SerializeField] private TextMeshProUGUI butterflySecondText;
    [SerializeField] private TextMeshProUGUI butterflyThridText;
    [SerializeField] private TextMeshProUGUI butterflyFourthText;
    public void IncrementButterflyCount(string butterflyType)
    {
        switch (butterflyType)
        {
            case "Blue":
                butterflyFirstCount++;
                Debug.Log(butterflyFirstCount);
                butterflyFirstText.text = butterflyFirstCount.ToString();
                break;
            case "Orange":
                butterflySecondCount++;
                butterflySecondText.text = butterflySecondCount.ToString();

                break;
            case "Purple":
                butterflyThirdCount++;
                butterflyThridText.text = butterflyThirdCount.ToString();

                break;
            case "Magic":
                butterflyFourthCount++;
                butterflyFourthText.text = butterflyFourthCount.ToString();

                break;
        }
    }
}
