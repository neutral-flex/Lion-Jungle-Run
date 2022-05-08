using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timee : MonoBehaviour
{
    public static Timee time;
    public float Timer;
    public Text TimerScore;
    public Text BestTime;
    public Text TwoTime;
   

    public float NextTarget;
    // Start is called before the first frame update
    void Start()
    {
        time = this;
    }

    // Update is called once per frame
    void Update()
    {
       

        var ts = TimeSpan.FromSeconds(Timer);
        TimerScore.text = string.Format("{0:00}:{1:00}", ts.TotalMinutes, ts.Seconds);
        TwoTime.text = string.Format("Time : "+"{0:00}:{1:00}", ts.TotalMinutes, ts.Seconds);
        
        var bestTs = TimeSpan.FromSeconds(PlayerPrefs.GetFloat("BestTime"));
        BestTime.text = string.Format("Best Time : "+"{0:00}:{1:00}", bestTs.TotalMinutes, bestTs.Seconds);


        if (PlayerPrefs.GetFloat("BestTime") < Timer)
        {
            PlayerPrefs.SetFloat("BestTime", Timer);
        }

        if (Timer >= NextTarget)
        {
            Enemy.instance.Speed += 0.5f;
            Player.pl.Speed += 0.5f;
            NextTarget += 15;

        }

        if (Player.pl.Play == true)
        {
            Timer += Time.deltaTime;

        }
    }
}
