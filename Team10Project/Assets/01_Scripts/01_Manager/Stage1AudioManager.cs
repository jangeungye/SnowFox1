using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1AudioManager : MonoBehaviour
{
    [SerializeField]
    AudioSource stage1AudioSource;

    [Range(0.0f, 1.0f)]
    [SerializeField]
    public float volume = 0.5f;

    private string volumeKey = "VolumeSetting";

    void Start()
    {
        // 저장된 설정값이 있을 경우 불러오기, 없을 경우 기본값(0.5f) 사용
        if (PlayerPrefs.HasKey(volumeKey))
        {
            volume = PlayerPrefs.GetFloat(volumeKey);
        }

        stage1AudioSource.volume = volume;
        stage1AudioSource.Play();
    }

    void Update()
    {
        stage1AudioSource.volume = volume;
    }

    public void VolumeMinus()
    {
        volume -= 0.1f;
        // 설정값을 PlayerPrefs에 저장
        PlayerPrefs.SetFloat(volumeKey, volume);
        PlayerPrefs.Save();
    }

    public void VolumePlus()
    {
        volume += 0.1f;
        // 설정값을 PlayerPrefs에 저장
        PlayerPrefs.SetFloat(volumeKey, volume);
        PlayerPrefs.Save();
    }
}
