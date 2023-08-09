using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3AudioManager : MonoBehaviour
{
    [SerializeField]
    AudioSource stage1AudioClip;



    void Start()
    {
        stage1AudioClip.Play();
    }
}
