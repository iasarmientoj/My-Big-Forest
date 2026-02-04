using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    public string prefix = "Hongos: ";
    public int totalMushrooms = 10;

    private void Start()
    {
        UpdateCounter(0);
    }

    private void OnEnable()
    {
        PlayerProgress.OnMushroomCollected += UpdateCounter;
    }

    private void OnDisable()
    {
        PlayerProgress.OnMushroomCollected -= UpdateCounter;
    }

    private void UpdateCounter(int count)
    {
        if (counterText != null)
        {
            counterText.text = prefix + count.ToString("00") + "/" + totalMushrooms.ToString("00");
        }
    }
}
