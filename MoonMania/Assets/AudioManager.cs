using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioSource menuSource;

    public AudioClip backgroundMusic;
    public AudioClip jumpClip;


    private void Awake()
    {
        // Singleton setup so it persists across scenes
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadAudioSettings();
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("Music", 1) == 1)
        {
            musicSource.clip = backgroundMusic;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public AudioClip clickSound;

    public void PlayClick()
    {
        PlayMenuSound(clickSound);
    }

    public void PlayJumpSFX()
    {
        PlaySFX(jumpClip);
    }

    public void PlaySFX(AudioClip clip)
    {
        if (PlayerPrefs.GetInt("SFX", 1) == 1)
            sfxSource.PlayOneShot(clip);
    }

    public void PlayMenuSound(AudioClip clip)
    {
        if (PlayerPrefs.GetInt("Menu", 1) == 1)
            menuSource.PlayOneShot(clip);
    }

    public void ToggleMusic(bool isOn)
    {
        musicSource.mute = !isOn;
        PlayerPrefs.SetInt("Music", isOn ? 1 : 0);
    }

    public void ToggleSFX(bool isOn)
    {
        PlayerPrefs.SetInt("SFX", isOn ? 1 : 0);
    }

    public void ToggleMenu(bool isOn)
    {
        PlayerPrefs.SetInt("Menu", isOn ? 1 : 0);
    }

    public void LoadAudioSettings()
    {
        ToggleMusic(PlayerPrefs.GetInt("Music", 1) == 1);
        ToggleSFX(PlayerPrefs.GetInt("SFX", 1) == 1);
        ToggleMenu(PlayerPrefs.GetInt("Menu", 1) == 1);
    }
}
