using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private static bool stopTime; 
    public static string time;
    public static int sec = 0;
    public static int min = 0;
    int p1 = 0;
    int p2 = 0;
    int p3 = 0;
    int p4 = 0;


    void Start()
    {
        stopTime = false;
    }
        

    void Update()
    {
        //Realiza a conversão do tempo em segundos para o formato 00:00
        sec = Convert.ToInt32(Time.timeSinceLevelLoad);
        min = Convert.ToInt32(sec / 60);
        if (Convert.ToInt32(sec / 60) > 0)
        {
            p1 = sec - 100 * Convert.ToInt32(sec / 100);
            p1 = p1 - 10 * Convert.ToInt32(p1 / 10);
            p2 = sec - 60 * Convert.ToInt32(sec / 60);
            p2 = Convert.ToInt32((p2 - 60 * Convert.ToInt32(p2 / 60))/10);
            p3 = Convert.ToInt32(sec / 60) - 10 * (Convert.ToInt32(sec / 600));
            p4 = Convert.ToInt32(sec / 600);
        }
        else
        {
            p1 = sec - 10 * Convert.ToInt32(sec / 10);
            p2 = Convert.ToInt32(sec/10) - 60 * Convert.ToInt32(p2 / 60);
        }
        if (!stopTime)
            time = (p4 + "" + p3 + ":" + p2 + "" + p1);             


    }
        
    public static void FreezeTime()
    {
        stopTime = true;
    }
}
