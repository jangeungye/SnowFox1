using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageOnButton : MonoBehaviour
{
    float stage1Cool;
    float stage2Cool;
    float stage3Cool;

    bool isStage1Click;
    bool isStage2Click;
    bool isStage3Click;

    void Update()
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
}
