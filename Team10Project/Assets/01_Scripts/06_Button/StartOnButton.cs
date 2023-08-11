using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartOnButton : MonoBehaviour
{
    [SerializeField]
    GameObject[] popup;

    void Start()
    {
        popup[0].SetActive(true);
        popup[1].SetActive(false);
        popup[2].SetActive(false);
        popup[3].SetActive(false);
        popup[4].SetActive(false);
    }
    void Update()
    {
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
        popup[1].SetActive(true);
    }

    public void OnSettingButton()
    {
        popup[0].SetActive(false);
        popup[2].SetActive(true);
    }

    public void OnKeySettingButton()
    {
        popup[2].SetActive(false);
        popup[3].SetActive(true);
    }

    public void OnCreditButton()
    {
        popup[0].SetActive(false);
        popup[4].SetActive(true);
    }

    public void OnExitButton()
    {
        Application.Quit();
    }
}
