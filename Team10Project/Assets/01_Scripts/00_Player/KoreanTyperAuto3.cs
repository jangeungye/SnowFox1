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
public class KoreanTyperAuto3 : MonoBehaviour
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
    int textNumber;


    [SerializeField]
    bool isTalking;

    void Update()
    {
        if (isTalking)
        {
            if (textNumber == 0 || textNumber == 2 ||  textNumber == 4 || textNumber == 11 || textNumber == 15
                || textNumber == 16 || textNumber == 19 || textNumber == 20)
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

    [SerializeField]
    Inventory inventory;

    public void NPC()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !isTalking)
        {
            if (textNumber >= 24)
            {
                deleteObj[1].SetActive(false);
                deleteObj[0].SetActive(true);  
                texts[0].SetActive(false);
                textNumber = 0;
                inventory.NPC3NumberPlus();
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
        //=======================================================================================================
        // Initializing | 초기화
        //=======================================================================================================
        string[] npc1Strings = new string[24]{ "나 아줌마 알아! 사진에서 봤어!",
                                              "내가 떨어뜨린 가족사진을 봤나보구나..",
                                              "응! 그때의 아줌마는 활짝 웃고 있던데, 지금은 많이 아파보여.",
                                              " ... 응.. 너가 보고 있는그대로 나는 지금 꽤 많이 다친 상태란다..",
                                              "아줌마는 어쩌다 이렇게 다치게 된거야?",
                                              "생존 물품들을 얻기 위해 남편과 함께 도시로 왔어, 소중한 딸을 마을에 혼자 두고 말이야..",
                                              "하지만 이곳의 이상기후의 진행 속도는 남편과 내가 생각한 것보다 더..",
                                              "아주 빠르게 이 지구를 삼키고 있었어.. 우리 둘은 살기 위해 온갖 노력을 다 했지만..",
                                              "나는 혼자선 걸을 수 없을만큼 다쳐버려서 결국 날 두고 남편을 딸한테 돌아가게 설득했지..",
                                              "그래서 나 혼자 이곳에 남게 된거란다..",
                                              "아아..... 소중한 내 딸..... 이렇게 될거였다면 널 한 번이라도 더 안아줄걸... 혼자서 얼마나 무섭고 추울까.....,",
                                              "여기 오기 전에 아주머니의 딸과 만났어! 사진을 주고 선물 받은 건데 이거 아줌마 가져!",
                                              "이건.. 내가 딸에게 생일선물로 준 리본이네. 꽤 옛날에 준거라 잃어버렸을거라 생각했는데..",
                                              "그 어린 아이가 소중함이라는 걸 알고 이렇게 잘 가지고 있어줬구나.",
                                              "그런 아이를 혼자 두고 나온 난 정말..",
                                              "아이는 기 죽지않고 혼자서도 잘 기다리고 있어!",
                                              "안좋은 일이 생기기 전에 분명 아줌마의 남편과 만났을거야!",
                                              "그거 정말 기쁜 소식인 걸.. 눈을 감기 전에.. 그런 이야기를 들으니.. 안심이 되는구나..",
                                              "전에 주운 건데 반짝이는 게 너와 잘 어울리구나.. 너 가지렴..",
                                              "( 기억의 조각3 획득 )",
                                              "고마워!",
                                              "그 아이와 남편이 꼭.. 살아남았으면.. 좋겠어..",
                                              "먼 미래에 다시.. 만나면.. 그땐 꼭.. 많이 사랑한다고..",
                                              "( 너무 피곤해서 말을 하다 잠에 든 것일까? 아줌마의 온몸이 얼음장처럼 차갑다. )"
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

