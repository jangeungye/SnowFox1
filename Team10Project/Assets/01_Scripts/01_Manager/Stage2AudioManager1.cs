using UnityEngine;

public class Stage2AudioManager : MonoBehaviour
{
    [SerializeField]
    AudioSource stage2AudioSource;

    [SerializeField]
    AudioManagerSettings audioManagerSettings;

    void Start()
    {
        stage2AudioSource.volume = audioManagerSettings.volume;
        stage2AudioSource.Play();
    }

    void Update()
    {
        stage2AudioSource.volume = audioManagerSettings.volume;
    }

    public void VolumeMinus()
    {
        audioManagerSettings.volume -= 0.1f;
    }

    public void VolumePlus()
    {
        audioManagerSettings.volume += 0.1f;
    }
}