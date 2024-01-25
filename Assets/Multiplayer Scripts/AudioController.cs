using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;
    public AudioClip[] audioClips;

    private bool menuThemePlaying = false;

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
        audioSource.volume = volumeSlider.value;
        volumeSlider.onValueChanged.AddListener(OnVolumeSliderChanged);
    }

    void Update()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "MAIN MENU TEACHER" || currentScene == "MAIN MENU STUDENT")
        {
            if (!menuThemePlaying){
                PlayAudioClip(0);
                menuThemePlaying = true;
            }
        }
        else
        {
            menuThemePlaying = false;
        }

        if (volumeSlider == null){
        GameObject sliderObject = GameObject.FindWithTag("Slider");
        volumeSlider = sliderObject.GetComponent<Slider>();
        audioSource.volume = volumeSlider.value;
        volumeSlider.onValueChanged.AddListener(OnVolumeSliderChanged);
        }
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
