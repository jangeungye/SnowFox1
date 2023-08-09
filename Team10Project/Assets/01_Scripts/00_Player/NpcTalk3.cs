using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcTalk3 : MonoBehaviour
{
    [SerializeField]
    KoreanTyperAuto3 koreanTyper3;


    [SerializeField]
    bool isNpc3;

    void Update()
    {
        NPC();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NPC3"))
        {
            isNpc3 = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NPC3"))
        {
            isNpc3 = false;
        }
    }
    void NPC()
    {

        if (isNpc3)
        {
            koreanTyper3.NPC();
        }
        else
        {
            koreanTyper3.NotNPC();
        }

    }
}
