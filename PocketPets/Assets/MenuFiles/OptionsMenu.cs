using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider = null;

    [SerializeField] private TextMeshProUGUI volumeTextUI = null;

    private void Start() //betölti az elõzõleg elmentett hangerõt megnyitáskor
    {
        LoadValues();
    }

    public void VolumeSlider(float volume)
    {
        volumeTextUI.text = volume.ToString("0.0");
    }

    public void SetVolumeButton()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        LoadValues();
    }

    public void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volumeValue;
        //AudioListener.volume = volumeValue;
        audioMixer.SetFloat("VolumeValue", volumeValue);
    }

    public AudioMixer audioMixer;

	public Toggle fullscreenToggle;

	public Dropdown resolutionDropdown;
	Resolution[] resolutions;

    void Start()
	{
		if (Screen.fullScreen != true)
		{
            fullscreenToggle.isOn = false;

		}
		else
		{
			fullscreenToggle.isOn = true;
		}
		resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

		List<string> options = new List<string>();

		int currentResolutionIndex = 0;
		for (int i = 0; i < resolutions.Length; i++)
		{
			string option = resolutions[i].width + "x" + resolutions[i].height + " @ " + resolutions[i].refreshRate + "hz";
			options.Add(option);

			if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
			{
				currentResolutionIndex = i;
			}
		}

		resolutionDropdown.AddOptions(options);
		resolutionDropdown.value = currentResolutionIndex;
		resolutionDropdown.RefreshShownValue();
	}

	public void SetResolution(int resolutionIndex)
	{
		Resolution resolution = resolutions[resolutionIndex];
		Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
	}
	public void SetVolume(float volume)
    {
        //az audiomixer paramétereinek ráhookolása kóddal hogy lehessen mozhatni a sliderrel
        audioMixer.SetFloat("volume", volume);
        Debug.Log(volume);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

}