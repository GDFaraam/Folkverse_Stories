using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;
    public AudioClip[] audioClips;

    // Singleton instance
    public static AudioController ACinstance;

    private void Awake()
    {
        // Ensure only one instance of AudioController exists
        if (ACinstance == null)
        {
            ACinstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Destroy the duplicate instance if another one is found
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Initialize the volume based on the slider value
        audioSource.volume = volumeSlider.value;

        // Add a listener for the slider's value change event
        volumeSlider.onValueChanged.AddListener(OnVolumeSliderChanged);
        PlayAudioClip(0);
    }

    void Update()
    {
        // You can add additional logic here if needed
    }

    void OnVolumeSliderChanged(float volume)
    {
        // Update the audio source volume when the slider value changes
        audioSource.volume = volume;
    }

    // Example method to play an audio clip
    public void PlayAudioClip(int clipIndex)
    {
        if (clipIndex >= 0 && clipIndex < audioClips.Length)
        {
            audioSource.clip = audioClips[clipIndex];
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Invalid audio clip index.");
        }
    }
}
