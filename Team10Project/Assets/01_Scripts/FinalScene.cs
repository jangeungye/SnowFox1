using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScence : MonoBehaviour
{
    [SerializeField]
    GameObject[] Imageandtext;

    void Start()
    {
        Imageandtext[0].SetActive(false);
        Imageandtext[1].SetActive(true);
        Imageandtext[2].SetActive(false);
    }


    public void SecondText()
    {
        Imageandtext[0].SetActive(true);
        Imageandtext[1].SetActive(false);
        Imageandtext[2].SetActive(true);
    }
}