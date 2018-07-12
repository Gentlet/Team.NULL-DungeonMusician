using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class AdsControl : MonoBehaviour
{
    public Text timer;
    
    private int nextTime = 0;
    private const string Android_ID = "2631515";

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("AdTime"))
        {
            PlayerPrefs.SetString("AdTime", DateTime.Now.Add(new TimeSpan(0, -5, 0)).ToString());
        }

        if (!Advertisement.isInitialized)
            Advertisement.Initialize(Android_ID, true);
    }
    private void Update()
    {
        if (Time.time >= nextTime)
        {
            DateTime time = Convert.ToDateTime(PlayerPrefs.GetString("AdTime"));

            if ((DateTime.Now - time).TotalMinutes >= 5)
            {
                timer.text = "무 료";
            }
            else
            {
                DateTime b = time.Add(new TimeSpan(0, 5, 0));

                TimeSpan a = b.Subtract(DateTime.Now);

                timer.text = string.Format("{0}:{1}", a.Minutes, (a.Seconds < 10 ? "0" + a.Seconds.ToString() : a.Seconds.ToString()));
            }

            nextTime++;

        }
    }

    public void PushWatch()
    {
        if (CheckTime())
        {
            ShowAds();

            //시청가능
        }
    }

    private bool CheckTime()
    {
        DateTime time = Convert.ToDateTime(PlayerPrefs.GetString("AdTime", DateTime.Now.Add(new TimeSpan(0, -5, 0)).ToString()));

        if ((DateTime.Now - time).TotalMinutes >= 5)
        {
            return true;
        }
        return false;
    }
    private void ShowAds()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };

            Advertisement.Show("rewardedVideo", options);
            PlayerPrefs.SetString("AdTime", DateTime.Now.ToString());
        }
    }
    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                {
                    Debug.Log("The ad was successfully shown.");
                    

                    // to do ...
                    // 광고 시청이 완료되었을 때 처리

                    break;
                }
            case ShowResult.Skipped:
                {
                    Debug.Log("The ad was skipped before reaching the end.");

                    // to do ...
                    // 광고가 스킵되었을 때 처리

                    break;
                }
            case ShowResult.Failed:
                {
                    Debug.LogError("The ad failed to be shown.");

                    // to do ...
                    // 광고 시청에 실패했을 때 처리

                    break;
                }
        }
    }
}
