using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KoreanTyper;                                                  // Add KoreanTyper namespace | 네임 스페이스 추가
using TMPro;

//===================================================================================================================
//  Auto Demo
//  자동으로 글자가 입력되는 데모
//===================================================================================================================
public class KoreanTyperAuto4 : MonoBehaviour
{
    [SerializeField]
    GameObject[] texts;

    [SerializeField]
    TextMeshProUGUI[] TestTexts;

    [SerializeField]
    int textNumber;

    [SerializeField]
    bool isTalking;

    [SerializeField]
    FinalScence final;
    void Start()
    {
        StartCoroutine(TypingText());
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !isTalking)
        {
            if (textNumber >= 8)
            {
                texts[0].SetActive(false);
                final.SecondText();
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
        string[] npc1Strings = new string[8]{ "인간들의 도움으로 기억의 조각을 3개나 모았다.",
                                              "내가 그 조각들을 합치고 그 조각을 보았을 때, 그 곳에는 나와 관련된 기억들이 얼핏 보였다.",
                                              "내가 연구원이라는 사람을 통해 인공적으로 만들어진 존재였다는 것",
                                              "그리고 그 사람의 실수로 내 존재가 지구를 이상기후로 덮었다는 것",
                                              "그리고 지구를 원래대로 돌리려면 내가 영원한 잠에 들면 된다는 것",
                                              "인간들은 모두 각자 동료, 가족, 물건 등 자신의 소중한 것을 가지고 있었다.",
                                              "그리고 그런 것들은 지구의 환경이 파괴될 수록 잃어버리기 쉬운 것들이였다.",
                                              "사람들이 자신의 소중한 것을 지키기 위해서는 아름다웠던 지구의 모습이 가장 중요해보였다.",
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

