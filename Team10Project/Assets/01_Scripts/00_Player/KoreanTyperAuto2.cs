using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KoreanTyper;                                               
using TMPro;

public class KoreanTyperAuto2 : MonoBehaviour
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
            if (textNumber == 1 || textNumber == 4 || textNumber == 7 || textNumber == 14 || textNumber == 20 || textNumber == 21)
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
            if (textNumber >= 23)
            {
                deleteObj[1].SetActive(false);
                deleteObj[0].SetActive(true);  
                texts[0].SetActive(false);
                textNumber = 0;
                inventory.NPC2NumberPlus();
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
        string[] npc1Strings = new string[23]{ "우와!! 여우다! 여우! 눈처럼 하얗고 예쁜 여우!",
                                              "너가 나의 멋짐을 좀 아는 아이구나!",
                                              "응!! 나 여우 정말 좋아해! 그러니 여우씨도 좋아!",
                                              "여우씨는 뭐하고 다니던 거야?",
                                              "나는 여행을 하고 있었어! 이곳저곳을 돌아다니며 말이지~",
                                              "재밌겠다!! 난 여기에서 계속 혼자라 심심한데..",
                                              "혹시 나랑 여기서 계속 같이 있어주면 안되는거야?",
                                              "그건 안 돼, 난 앞으로 계속 나아가며 내 기억을 위해 여행해야해!",
                                              "아아.. 그렇구나..! 바쁘..구나..",
                                              "나도 원래는 엄마와 아빠랑 이곳에 같이 살았는데 두 분 다 어느날 나를 위해서라며 다른 곳으로 떠나버리셨어... ",
                                              "나도 같이 가고 싶다고 했는데 위험하다며 혼자 두고....",
                                              " 그래서 혼자 여기서 잘 기다리고 있는 중이야!",
                                              "하지만..... 가끔씩 엄마랑 아빠가 너무 보고 싶어서..... 눈물이 나와....",
                                              "( 아이의 눈에서 눈물 방울들이 떨어진다. )",
                                              "이거 너꺼야? 오다가 주웠거든.",
                                              "..! 나랑.. 엄마랑.. 아빠야..! 우리 엄마 아빠랑 찍은 가족사진이야!!",
                                              "이렇게라도 엄마랑 아빠 얼굴을 볼 수 있어서 좋다! 정말 고마워 여우씨!",
                                              "여우씨 덕분에 여기서 더 부모님을 기다려볼 수 있을 거 같아!",
                                              "이거 아까 잠깐 주변 돌아다니면서 주운건데 여우씨 줄게!",
                                              "아 그리고 이건 내 리본인데 예쁜 여우씨한테 잘어울리니 이것도 줄게!",
                                              "( 기억의 조각2, 어린아이의 리본 획득 )",
                                              "고마워! 난 이제 다시 여행을 떠날거야! 나중에 또 만났으면 좋겠다",
                                              "응!! 나도 여우씨 또 만나고 싶어! 그땐 꼭 같이 재밌는 놀이하면서 놀자!!"
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

