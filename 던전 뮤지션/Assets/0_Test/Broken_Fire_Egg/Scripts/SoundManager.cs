using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingletonGameObject<SoundManager>
{
    public AudioSource[] EffectSounds;
    public AudioSource[] Musics;
    public int IsEffectOn;
    public int isBGMOn;


    private void Start()
    {
        IsEffectOn = PlayerPrefs.GetInt("IsEffectOn", 1);
        isBGMOn = PlayerPrefs.GetInt("IsBGMOn", 1);

      //  SwitchSoundStatus();
    }
    public void SwitchSoundStatus(bool eft)
    {
        if (eft)
        {
            if (IsEffectOn == 1)
            {
                IsEffectOn = 0;
                PlayerPrefs.SetInt("IsEffectOn", 0);

                for (int i = 0; i < EffectSounds.Length; i++)
                    EffectSounds[i].mute = true;
            }
            else
            {
                IsEffectOn = 1;
                PlayerPrefs.SetInt("IsEffectOn", 1);

                for (int i = 0; i < EffectSounds.Length; i++)
                    EffectSounds[i].mute = false;
            }
        }
        else
        {
            if (isBGMOn == 1)
            {
                isBGMOn = 0;
                PlayerPrefs.SetInt("isBGMOn", 0);

                for (int i = 0; i < Musics.Length; i++)
                    Musics[i].mute = true;
            }
            else
            {
                isBGMOn = 1;
                PlayerPrefs.SetInt("isBGMOn", 1);

                for (int i = 0; i < Musics.Length; i++)
                    Musics[i].mute = false;
            }
        }
        PlayerPrefs.Save();
    }
    public void ChangeVolume(float value)
    {
        for (int i = 0; i < Musics.Length; i++)
        {
            Musics[i].volume = value;
        }
        PlayerPrefs.SetFloat("MainSoundVolume", value);
        PlayerPrefs.Save();
    }
    /// <summary>이펙트 사운드 출력</summary>
    /// <param name="index"></param>
    public void PlayEffectSound(int index)
    {
        if (IsEffectOn == 1)
            EffectSounds[index].Play();
    }
    /// <summary>노래 출력</summary>
    public void PlayMusic(int index)
    {
        Musics[index].Play();
    }
    /// <summary>플레이중인 음악 일시정지, 해당 음악의 인덱스값 리턴</summary>
    public int PauseMusic()
    {
#pragma warning disable CS0162 // 접근할 수 없는 코드가 있습니다.
        for (int i = 0; i < Musics.Length; i++)
#pragma warning restore CS0162 // 접근할 수 없는 코드가 있습니다.
        {
            if (Musics[i].isPlaying)
                Musics[i].Pause();
            return i;
        }
        return -1;
    }
    /// <summary>음악 일시정지 해제</summary>
    public void UnpauseMusic(int index)
    {
        if (index < 0)
            return;
        Musics[index].UnPause();
    }
    /// <summary>플레이 중인 음악 멈추기</summary>
    public void StopMusic()
    {
       for(int i=0;i<Musics.Length;i++)
            if(Musics[i].isPlaying == true)
            {
                Musics[i].Stop();
                return;
            }
    }

    public AudioSource GetPlayingMusic()
    {
        for (int i = 0; i < Musics.Length; i++)
        {
            if (Musics[i].isPlaying)
                return Musics[i];
        }
        return null;

    }
}

