using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVisual : MonoBehaviour
{
    private const int SAMPLE_SIZE = 1024;

    public float rmsValue;
    public float dbValue;
    public float pitchValue;

    public float visualModifier = 50.0f;
    public float smoothSpeed = 10.0f;
    public float keepPercentage = 0.5f;

    public SpriteRenderer[] visualizeObj;

    private AudioSource source;
    private float[] samples;
    private float[] spectrum;
    private float sampleRate;

    private Transform[] visualList;
    private float[] visualScale;
    private float maxVisualScale = 3.1f;

    private void Start()
    {
        source = FindObjectOfType<AudioSource>();
        samples = new float[SAMPLE_SIZE];
        spectrum = new float[SAMPLE_SIZE];
        sampleRate = AudioSettings.outputSampleRate;

        Init();
    }
    private void Init()
    {
        visualList = new Transform[visualizeObj.Length];
        visualScale = new float[visualizeObj.Length];

        for (int i = 0; i < visualizeObj.Length; i++)
        {
            visualList[i] = visualizeObj[i].transform;
        }
    }

    private void Update()
    {
        if (source != null)
        {
            AnalyzeSound();
            UpdateVisual();
        }
        else
        {
            source = FindObjectOfType<AudioSource>();
        }
    }
    private void UpdateVisual()
    {
        int visualIndex = 0;
        int spectrumIndex = 0;
        int averageSize = (int)(SAMPLE_SIZE * keepPercentage / visualizeObj.Length);

        while (visualIndex < visualizeObj.Length)
        {
            int j = 0;
            float sum = 0f;
            while (j < averageSize)
            {
                sum += spectrum[spectrumIndex];
                spectrumIndex++;
                j++;
            }

            float scaleY = sum / averageSize * visualModifier;
            visualScale[visualIndex] -= Time.deltaTime * smoothSpeed;
            if (visualScale[visualIndex] < scaleY)
                visualScale[visualIndex] = scaleY;

            if (visualScale[visualIndex] > maxVisualScale)
                visualScale[visualIndex] = maxVisualScale;

            //visualList[visualIndex].localScale = new Vector3(0.3f, 1.6f, 1.0f) +  Vector3.up * visualScale[visualIndex];

            visualizeObj[visualIndex].size = new Vector2(visualizeObj[visualIndex].size.x, 0.2f + visualScale[visualIndex]);

            visualIndex++;
        }
    }
    private void AnalyzeSound()
    {
        source.GetOutputData(samples, 0);

        //Get RMS
        int i = 0;
        float sum = 0f;
        for (; i < SAMPLE_SIZE; i++)
        {
            sum += samples[i] * samples[i];
        }
        rmsValue = Mathf.Sqrt(sum / SAMPLE_SIZE);

        //Get DB value
        dbValue = 20 * Mathf.Log10(rmsValue / 0.1f);

        //Get sound spectrum
        source.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

        //Find pitch
        float maxV = 0;
        int maxN = 0;
        for (i = 0; i < SAMPLE_SIZE; i++)
        {
            if (!(spectrum[i] > maxV) || !(spectrum[i] > 0.0f))
            {
                maxV = spectrum[i];
                maxN = i;
            }
        }
        float freqN = maxN;
        if (maxN > 0 && maxN < SAMPLE_SIZE - 1)
        {
            var dL = spectrum[maxN - 1] / spectrum[maxN];
            var dR = spectrum[maxN + 1] / spectrum[maxN];
            freqN += 0.5f * (dR * dR - dL * dL);
        }
        pitchValue = freqN * (sampleRate / 2f) / SAMPLE_SIZE;
    }
}
