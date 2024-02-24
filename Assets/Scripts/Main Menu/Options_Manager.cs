using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Options_Manager : MonoBehaviour
{
    public Slider Volume_Slider;
    public Dropdown resolution_Dropdown;
    public Dropdown textureQuality_Dropdown;
    public Dropdown vSync_DropDown;
    public Toggle FullScreen_Toggle;
    public Button applyButton;

    public AudioSource musicSource;
    public Resolution[] resolution;
    public Options gameSettings;

    OptionsHolder optionsHolder;

    private void Awake()
    {
        optionsHolder = FindObjectOfType<OptionsHolder>();
    }

    void OnEnable()
    {
        //gameSettings = new Options();
        gameSettings = optionsHolder.GetOptions();


        Volume_Slider.onValueChanged.AddListener(delegate { OnVolumeChange(); });
        resolution_Dropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        textureQuality_Dropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        vSync_DropDown.onValueChanged.AddListener(delegate { OnvSyncChange(); });
        FullScreen_Toggle.onValueChanged.AddListener(delegate { OnFullScreenToggle(); });
        applyButton.onClick.AddListener(delegate { OnButtonApply(); });

        resolution = Screen.resolutions;
        foreach(Resolution resolution in resolution)
        {
            resolution_Dropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }
        LoadSettings();
    }

    public void OnVolumeChange()
    {
        musicSource.volume = gameSettings.Volume = Volume_Slider.value;
    }

    public void OnFullScreenToggle()
    {
        gameSettings.Full_screen = Screen.fullScreen = FullScreen_Toggle.isOn;
    }

    public void OnResolutionChange()
    {
        Screen.SetResolution(resolution[resolution_Dropdown.value].width, resolution[resolution_Dropdown.value].height, Screen.fullScreen);
        gameSettings.Resolution_Index = resolution_Dropdown.value;
    }

    public void OnTextureQualityChange()
    {
        QualitySettings.globalTextureMipmapLimit = gameSettings.Texture_quality = textureQuality_Dropdown.value;
    }

    public void OnvSyncChange()
    {
        QualitySettings.vSyncCount = gameSettings.vSync = vSync_DropDown.value;
    }

    public void OnButtonApply()
    {
        SaveSettings();
    }

    public void SaveSettings()
    {
        //string jsonData = JsonUtility.ToJson(gameSettings, true);
        //File.WriteAllText(Application.persistentDataPath + "/Options.json", jsonData);

        optionsHolder.SetOptions(gameSettings);
    }

    public void LoadSettings()
    {
        gameSettings = optionsHolder.GetOptions(); 
        //gameSettings = JsonUtility.FromJson<Options>(File.ReadAllText(Application.persistentDataPath + "/Options.json"));

        Volume_Slider.value = gameSettings.Volume;
        vSync_DropDown.value = gameSettings.vSync;
        textureQuality_Dropdown.value = gameSettings.Texture_quality;
        resolution_Dropdown.value = gameSettings.Resolution_Index;
        FullScreen_Toggle.isOn = gameSettings.Full_screen;
        Screen.fullScreen = gameSettings.Full_screen;

        resolution_Dropdown.RefreshShownValue();
    }
}
