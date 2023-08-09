using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseEvent2 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    List<GameObject> images = new List<GameObject>();

    public void OnPointerEnter(PointerEventData eventData)
    {
        images[0].transform.localScale = new Vector3(1.5f, 1.5f, 1);

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        images[0].transform.localScale = new Vector3(1, 1, 1);
    }
}
