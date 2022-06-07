using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeOutController : MonoBehaviour
{
    public Text TextTimer;
    public PopupController PopupController;
    public Player2DController PlayerController;
    public float timeOnSec = 0; // in second
    public bool isActive;
    float s;

    // Update is called once per frame
    void Update()
    {
        int Minutes = Mathf.FloorToInt(timeOnSec / 60); // 01
        int Seconds = Mathf.FloorToInt(timeOnSec % 60); // 30

        TextTimer.text = Minutes.ToString("00") + ":" + Seconds.ToString("00");

        s += Time.deltaTime;

        if(isActive == true)
        {
            if (s >= 1)
            {
                timeOnSec--;
                s = 0;
            }
        }
        

        if (timeOnSec == 0)
        {
            PopupController.showPopup();
            PlayerController.ctrlDisabled(true);
            isActive = false;
        }


    }

    public void timeActive(bool status)
    {
        isActive = status;
    }

    public void timeAdd(float sec)
    {
        timeOnSec += sec;
    }
}
