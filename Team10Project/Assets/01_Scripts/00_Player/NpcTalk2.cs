using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcTalk2 : MonoBehaviour
{
    [SerializeField]
    KoreanTyperAuto2 koreanTyper2;

    [SerializeField]
    bool isNpc2;


    void Update()
    {
        NPC();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NPC2"))
        {
            isNpc2 = true;
        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NPC2"))
        {
            isNpc2 = false;
        }
    }

    void NPC()
    {
        if (isNpc2)
        {
            koreanTyper2.NPC();
        }
        else
        {
            koreanTyper2.NotNPC();
        }
    }
}
