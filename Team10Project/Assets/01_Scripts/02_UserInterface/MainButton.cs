using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;

public class MainButon : MonoBehaviour
{

    [SerializeField]
    GameObject[] popup;

    float fixedWidth;
    float fixedHeight;

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

    bool isOneClick;

    void Start()
    {
        StateText();       
        popup[0].SetActive(true);
        popup[1].SetActive(false);
        popup[2].SetActive(false);
        popup[3].SetActive(false);

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
        CoolTime();

        fullScreenSettingText.text = fullScreenTextList[fullScreenCount];
        resolutionSettingText.text = resolutionTextList[resolutionCount];
        soundSettingText.text = $"{soundCount}";
        print(soundCount);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            popup[0].SetActive(true);
            popup[1].SetActive(false);
            popup[2].SetActive(false);
            popup[3].SetActive(false);
            popup[4].SetActive(false);
        }
    }

    public void OnStartButton()
    {
        popup[0].SetActive(false);
        popup[3].SetActive(true);   
    }

    public void OnSettingButton()
    {
        popup[0].SetActive(false);
        popup[1].SetActive(true);
    }
    public void OnKeySettingButton()
    {
        popup[1].SetActive(false);
        popup[4].SetActive(true);
    }
    public void OnCreditButton()
    {
        popup[0].SetActive(false);
        popup[2].SetActive(true);
    }
    public void OnExitButton()
    {
        Application.Quit();
    }

    float stage1Cool;
    float stage2Cool;
    float stage3Cool;

    bool isStage1Click;
    bool isStage2Click;
    bool isStage3Click;
    void CoolTime()
    {
        if (stage1Cool > 0)
        {
            stage1Cool -= Time.deltaTime;
        }
        else
        {
            stage1Cool = 0;
            isStage1Click = false;
        }


    }
    
    public void OnStage1Button()
    {
        if (isStage1Click)
        {
            SceneManager.LoadScene("GameScene1");
        }
        else
        {
            stage1Cool = 2f;
            isStage1Click = true;
        }
    }
    public void OnStage2Button()
    {
        if (isStage2Click)
            SceneManager.LoadScene("GameScene2");
        else
            isStage2Click = true;
    }
    public void OnStage3Button()
    {
        if (isStage3Click)
            SceneManager.LoadScene("GameScene3");
        else
            isStage3Click = true;
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
