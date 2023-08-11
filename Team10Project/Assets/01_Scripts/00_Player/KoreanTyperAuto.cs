using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KoreanTyper;                                                
using TMPro;

public class KoreanTyperAuto : MonoBehaviour
{
    [SerializeField]
    GameObject[] deleteObj;

    [SerializeField]
    GameObject[] charcterObj;

    [SerializeField]
    GameObject[] texts;

    [SerializeField]
    TextMeshProUGUI[] TestTexts;

    [SerializeField]
    Inventory inventory;

    [SerializeField]
    int textNumber;

    [SerializeField]
    bool isTalking;

    void Update()
    {
        if (isTalking)
        {
            if (textNumber == 0 || textNumber == 2 || textNumber == 4 || textNumber == 8 || textNumber == 13 || textNumber == 15 || textNumber == 16)
            {
                charcterObj[0].SetActive(true);
                charcterObj[1].SetActive(false);
            }
            else
            {
                charcterObj[0].SetActive(false);
                charcterObj[1].SetActive(true);
            }
        }
    }
    

    public void NPC()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !isTalking)
        {
            if (textNumber >= 17)
            {
                deleteObj[1].SetActive(false);
                deleteObj[0].SetActive(true);  
                texts[0].SetActive(false);
                textNumber = 0;
                inventory.NPC1NumberPlus();
                inventory.StartImage();
            }
            else
            {
                deleteObj[1].SetActive(true);
                deleteObj[0].SetActive(false);
                texts[0].SetActive(true);
                StartCoroutine(TypingText());            
            }
        }
    }

    public void NotNPC()
    {
        textNumber = 0;
        
        texts[0].SetActive(false);

        deleteObj[0].SetActive(true);
        deleteObj[1].SetActive(false);

        charcterObj[0].SetActive(false);
        charcterObj[1].SetActive(false);
        
    }

    IEnumerator TypingText()
    {
        string[] npc1Strings = new string[17]{ "안녕!",
                                              "헛것이 보이는 게 다른 것도 아니고 여우라니.. 나 미쳐버린 건가..",
                                              "헛것이 아니라 진짜 맞거든!",
                                              "....",
                                              "여기서 혼자 뭐해? 무슨 일 있었어?",
                                              ".. 동료가 있었는데. 난 그 동료를 무시했어. 분명.. 내가 살릴 수도 있었을텐데..",
                                              "갑작스럽게 일어난 눈사태 상황에 놀라서 난 동료를 버리고 혼자 도망쳤어...",
                                              "아.. 사람이 어떻게 이렇게 무력하고 어리석을 수 있을까.... 한 번만 더... 기회가 있다면...",
                                              "이거 여기 오다가 주웠는데, 가질래?",
                                              "...",
                                              "이건.. 동료의 군번줄이네..",
                                              "( 아저씨는 손으로 군번줄을 꽉 쥐고 울 것 같은 표정을 지었다.)",
                                              "헛것한테서 이런 걸 받는다니.. 나 정말 미쳐버렸구나.. 하하",
                                              "헛것이 아니라니까!",
                                              ".. 여우야 그러면 이건 너 가져라. 주웠는데 나한테는 쓸모가 없어.",
                                              "(기억의 조각1 획득)",
                                              "우와 엄청 반짝거려! 고마워 아저씨!"
                                              };


        foreach (TextMeshProUGUI t in TestTexts)
            t.text = "";



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

