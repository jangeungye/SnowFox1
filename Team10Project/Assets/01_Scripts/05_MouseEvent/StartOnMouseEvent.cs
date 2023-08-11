using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StartOnMouseEvent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    List<GameObject> images = new List<GameObject>();

    public void OnPointerEnter(PointerEventData eventData)
    {
        images[0].SetActive(false);
        images[1].SetActive(true);

        Invoke("Exit", 2);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        images[0].SetActive(true);
        images[1].SetActive(false);
    }

    void Exit()
    {
        images[0].SetActive(true);
        images[1].SetActive(false);
    }
}
