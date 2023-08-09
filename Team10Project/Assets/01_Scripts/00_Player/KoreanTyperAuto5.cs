using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KoreanTyper;                                                  // Add KoreanTyper namespace | 네임 스페이스 추가
using TMPro;
using UnityEngine.SceneManagement;

//===================================================================================================================
//  Auto Demo
//  자동으로 글자가 입력되는 데모
//===================================================================================================================
public class KoreanTyperAuto5 : MonoBehaviour
{
    [SerializeField]
    GameObject[] texts;

    [SerializeField]
    TextMeshProUGUI[] TestTexts;

    [SerializeField]
    int textNumber;

    [SerializeField]
    bool isTalking;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !isTalking)
        {
            if (textNumber >= 7)
            {
                texts[0].SetActive(false);
                SceneManager.LoadScene("StartScene");
            }
            else
            {
                texts[0].SetActive(true);
                StartCoroutine(TypingText());

            }
        }
    }

    IEnumerator TypingText()
    {
        //=======================================================================================================
        // Initializing | 초기화
        //=======================================================================================================
        string[] npc1Strings = new string[7]{ "나에게는 아직 소중한 것이라는 게 없어.",
                                              "하지만 적어도 내가 만나온 그들에겐 소중한 게 있었어",
                                              "지구의 인간들이 아름다운 지구의 환경 속에서 다시 각자의 소중한 삶을 이어나갔으면..",
                                              "그들이 평범하다고 느꼈던 지구의 소중함을 깨달았으면..",
                                              "여행을 너무 열심히 했나봐! 이제 나도 피곤해서 자야겠어!",
                                              "나와 함께 여행 해줘서 고마웠어!",
                                              "그러면 잘 자.",
                                              };

        foreach (TextMeshProUGUI t in TestTexts)
            t.text = "";
        //=======================================================================================================


        //=======================================================================================================
        //  Typing effect | 타이핑 효과
        //=======================================================================================================



        int strTypingLength = npc1Strings[textNumber].GetTypingLength();

        for (int i = 0; i <= strTypingLength; i++)
        {
            isTalking = true;
            TestTexts[0].text = npc1Strings[textNumber].Typing(i);
            yield return new WaitForSeconds(0.05f);
        }
        isTalking = false;
        textNumber++;
    }
}

