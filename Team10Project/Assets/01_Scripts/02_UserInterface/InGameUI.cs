using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class InGameUI : MonoBehaviour
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

    int fullScreenCount = 0;
    int resolutionCount;
    int soundCount;
    

    List<(int width, int height)> screenResolution = new List<(int width, int height)>();

    [SerializeField]
    List<GameObject> startTitle = new List<GameObject>();
    [SerializeField]
    List<Image> startTitleImage = new List<Image>();

    [SerializeField]
    GameObject imGameUI;

    float fadeSpeed = 0.5f;

    int titleNumber;

    bool isInventoryPopup;
    bool isPausePopup;
    bool isOneClick;

    

    void Start()
    {
        imGameUI.SetActive(true);

        Invoke("StartTitle", 1); //¼öÁ¤ÇÊ¿ä

        StateText();

        popup[0].SetActive(false);

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
        if (!isInventoryPopup && Input.GetKeyDown(KeyCode.I))
        {
            popup[1].SetActive(true);
            isInventoryPopup = true;
            Time.timeScale = 0;
        }
        else if (isInventoryPopup && Input.GetKeyDown(KeyCode.I))
        {
            popup[1].SetActive(false);
            isInventoryPopup = false;
            Time.timeScale = 1;
        }

        fullScreenSettingText.text = fullScreenTextList[fullScreenCount];
        resolutionSettingText.text = resolutionTextList[resolutionCount];
        soundSettingText.text = $"{soundCount}";
        if (!isPausePopup && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            popup[0].SetActive(true);
            isPausePopup = true;
        }
        else if (isPausePopup && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1f;
            popup[0].SetActive(false);
            isPausePopup = false;
        }
    }
    public void OnMainSceneButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScene");
    }
    public void OnExitButton()
    {
        Application.Quit();
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

    public void Plustitle()
    {
        titleNumber++;
    }

    public void StartTitle()
    {
        startTitle[titleNumber].SetActive(true);

        SpriteRenderer spriteRenderer = startTitle[titleNumber].GetComponent<SpriteRenderer>();

        StartCoroutine(FadeIn()); //¼öÁ¤ÇÊ¿ä

    }

    IEnumerator FadeIn()
    {
        while (startTitleImage[titleNumber].color.a < 1f)
        {
            Color newColor = startTitleImage[titleNumber].color;
            newColor.a += Time.deltaTime * fadeSpeed;
            startTitleImage[titleNumber].color = newColor;
            yield return null;
        }

        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        while (startTitleImage[titleNumber].color.a > 0f)
        {
            Color newColor = startTitleImage[titleNumber].color;
            newColor.a -= Time.deltaTime * fadeSpeed;
            startTitleImage[titleNumber].color = newColor;
            yield return null;
        }


        startTitle[titleNumber].SetActive(false);
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
