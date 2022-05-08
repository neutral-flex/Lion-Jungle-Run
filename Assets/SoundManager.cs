using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public GameObject OnMusic;
    public GameObject OffMusic;

    public GameObject OnSound;
    public GameObject OffSound;

    public AudioSource audio1;
    public AudioSource audio2;
    public AudioSource audio3;
    public AudioSource audio4;
    public AudioSource MusicAudio;

    // Update is called once per frame
    void Update()
    {
        // 0 = On
        if (PlayerPrefs.GetInt("music") == 0)
        {
            OnMusic.SetActive(false);
            OffMusic.SetActive(true);
            MusicAudio.mute = false;
        } 
        // 1 = Off
        if (PlayerPrefs.GetInt("music") == 1)
        {
            OnMusic.SetActive(true);
            OffMusic.SetActive(false);
            MusicAudio.mute = true;
        }

       
        if (PlayerPrefs.GetInt("sound") == 0)
        {
            OnSound.SetActive(false);
            OffSound.SetActive(true);
            audio1.mute = false;
            audio2.mute = false;
            audio3.mute = false;
            audio4.mute = false;
        } if (PlayerPrefs.GetInt("sound") == 1)
        {
            OnSound.SetActive(true);
            OffSound.SetActive(false);
            audio1.mute = true;
            audio2.mute = true;
            audio3.mute = true;
            audio4.mute = true;
        }

    }

    public void OnMusicBTN()
    {
        PlayerPrefs.SetInt("music", 0);
    }public void OffMusicBTN()
    {
        PlayerPrefs.SetInt("music", 1);
    } public void OnSoundBTN()
    {
        PlayerPrefs.SetInt("sound", 0);
    }public void OffSoundBTN()
    {
        PlayerPrefs.SetInt("sound", 1);
    }
}
