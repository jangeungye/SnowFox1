using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcTalk1 : MonoBehaviour
{
    [SerializeField]
    KoreanTyperAuto koreanTyper;

    [SerializeField]
    bool isNpc1;

    void Update()
    {
        NPC();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NPC1"))
        {
            isNpc1 = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NPC1"))
        {
            isNpc1 = false;
        }
    }

    void NPC()
    {

        if (isNpc1)
        {
            koreanTyper.NPC();
        }
        else
        {
            koreanTyper.NotNPC();
        }
    }
}
