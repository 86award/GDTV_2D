using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.345f;

    private void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
    }
    private void Update()
    {
        var musicPlayer = FindAnyObjectByType<MusicPlayer>();
        if (musicPlayer) musicPlayer.SetVolume(volumeSlider.value);
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        FindAnyObjectByType<LevelLoader>().LoadMainMenu();
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
    }
}
