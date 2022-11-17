using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenSettings : MonoBehaviour
{
    public Toggle fullscreenToggle;

    public Dropdown resolutionDropdown;
    Resolution[] resolutions;
    
    // Start is called before the first frame update
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
            string option = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate + "hz";
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

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
