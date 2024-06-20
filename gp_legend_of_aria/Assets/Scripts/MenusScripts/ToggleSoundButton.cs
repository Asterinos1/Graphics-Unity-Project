using UnityEngine;
using UnityEngine.UI;

public class ToggleSoundButton : MonoBehaviour
{
    private Button button;
    private AudioManager audioManager;
    private Image buttonImage;

    public Color enabledColor = Color.green;
    public Color disabledColor = new Color(0.56f, 0.93f, 0.56f); // Light green color

    void Start()
    {
        button = GetComponent<Button>();
        buttonImage = button.GetComponent<Image>();
        audioManager = FindObjectOfType<AudioManager>();
        button.onClick.AddListener(ToggleSound);

        // Set the initial color based on the audio state
        UpdateButtonColor();
    }

    void ToggleSound()
    {
        if (audioManager != null)
        {
            audioManager.ToggleSound();
            UpdateButtonColor();
        }
    }

    void UpdateButtonColor()
    {
        if (audioManager != null && audioManager.IsSoundEnabled())
        {
            buttonImage.color = enabledColor;
        }
        else
        {
            buttonImage.color = disabledColor;
        }
    }
}
