using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterLimit : MonoBehaviour
{
    public TMP_InputField inputField;
    public int maxCharacters = 50; // Change this value to set the maximum character limit

    private void Start()
    {
        // Subscribe to the onValueChanged event of the input field
        inputField.onValueChanged.AddListener(OnInputValueChanged);
    }

    private void OnInputValueChanged(string text)
    {
        // Check if the length of the input text exceeds the maximum character limit
        if (text.Length > maxCharacters)
        {
            // If it exceeds, truncate the input text to the maximum character limit
            inputField.text = text.Substring(0, maxCharacters);
        }
    }
}
