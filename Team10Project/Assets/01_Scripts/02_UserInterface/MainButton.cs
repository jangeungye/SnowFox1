using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;

public class MainButon : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI fullScreenSettingText;
    [SerializeField]
    TextMeshProUGUI resolutionSettingText;
    [SerializeField]
    TextMeshProUGUI soundSettingText;
    
    List<string> fullScreenTextList = new List<string>();
    List<string> resolutionTextList = new List<string>();

    int fullScreenCount;
    int resolutionCount;
    int soundCount = 5;

    List<(int width, int height)> screenResolution = new List<(int width, int height)>();

    float fixedWidth;
    float fixedHeight;

    bool isOneClick;

    void Start()
    {
        StateText();       

        Screen.SetResolution(1920, 1080, true);
        
        if (PlayerPrefs.HasKey("ChangeWidth"))
        {
            fixedWidth = PlayerPrefs.GetInt("ChangeWidth");
            fixedHeight = PlayerPrefs.GetInt("ChangeHeight");
        }
        else
        {
            fixedWidth = Screen.width;
            fixedHeight = Screen.height;
            PlayerPrefs.SetInt("ChangeWidth", (int)fixedWidth);
            PlayerPrefs.SetInt("ChangeHeight", (int)fixedHeight);
            PlayerPrefs.Save();
        }
    }

    void Update()
    {
        fullScreenSettingText.text = fullScreenTextList[fullScreenCount];
        resolutionSettingText.text = resolutionTextList[resolutionCount];
        soundSettingText.text = $"{soundCount}";
    }  
    
    public void ONFullScreenButton()
    {
        if (!isOneClick)
        {
            Screen.fullScreen = false;
            isOneClick = true;
            fullScreenCount = 1;
        }
        else
        {
            Screen.fullScreen = true;
            isOneClick = false;
            fullScreenCount = 0;
        }
    }

    public void OnResolutionRightButton()
    {
        resolutionCount++;
        if (resolutionCount > screenResolution.Count - 1)
        {
            resolutionCount = 0;
        }

        Screen.SetResolution(screenResolution[resolutionCount].width, screenResolution[resolutionCount].height, true);
    }

    public void OnResolutionLeftButton()
    {
        resolutionCount--;
        if (resolutionCount < 0)
        {
            resolutionCount = screenResolution.Count - 1; //¸®½ºÆ®ÀÇ ÃÖ´ë ÀÎµ¦½º
        }

        Screen.SetResolution(screenResolution[resolutionCount].width, screenResolution[resolutionCount].height, true);
    }

    public void OnSoundRightButton()
    {
        soundCount--;
        if (soundCount < 0)
        {
            soundCount = 0;
        }
    }

    public void OnSoundLeftButton()
    {
        soundCount++;
        if (soundCount > 10)
        {
            soundCount = 10;
        }
    }

    
    void StateText()
    {
        fullScreenCount = 0;
        resolutionCount = 0;
        soundCount = 5;
        fullScreenTextList.Add("ÄÑÁü");
        fullScreenTextList.Add("²¨Áü");

        screenResolution.Add((1920, 1080));
        screenResolution.Add((1600, 900));
        screenResolution.Add((1440, 900));
        screenResolution.Add((1280, 720));
        screenResolution.Add((1024, 768));
        screenResolution.Add((960, 720));

        resolutionTextList.Add("1920 x 1080");
        resolutionTextList.Add("1600 x 900");
        resolutionTextList.Add("1440 x 900");
        resolutionTextList.Add("1280 x 720");
        resolutionTextList.Add("1024 x 768");
        resolutionTextList.Add("960 x 720");

    }
}
