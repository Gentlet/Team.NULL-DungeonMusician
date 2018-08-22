using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioPeer : MonoBehaviour
{
    AudioSource audioSource;
    AudioSource _audioSource
    {
        get
        {
            if (audioSource == null)
            {
                audioSource = FindObjectOfType(typeof(AudioSource)) as AudioSource;
            }
            return audioSource;
        }
    }

    public static float[] _samples = new float[1024];
    public static float[] _freqBand = new float[20];

    private void Start()
    {
    }

    private void Update()
    {
        GetAudioSpectrum();
        MakeFrequenctBands();
    }

    void GetAudioSpectrum()
    {
        _audioSource.GetSpectrumData(_samples, 0, FFTWindow.Blackman);
    }
    void MakeFrequenctBands()
    {
        int num = 1;
        int count = 0;

        for (int i = 0; i < 20; i++)
        {
            if (i < 10)
            {
                float average = 0f;
                int sampleCount = (int)(Mathf.Pow(2, i));

                for (int j = 0; j < sampleCount; j++)
                {
                    average += _samples[count] * (count + 1);
                    count++;
                }

                average /= count;

                _freqBand[i] = average * 10;
            }
            else
            {
                _freqBand[i] = _freqBand[i - num];
                num += 2;
            }
        }
    }
}
