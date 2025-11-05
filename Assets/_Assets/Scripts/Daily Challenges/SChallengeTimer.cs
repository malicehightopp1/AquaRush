using System;
using TMPro;
using UnityEngine;
public class SChallengeTimer : MonoBehaviour
{
    public bool mTimerInProgress;
    private DateTime mTimerEnd;
    private TimeSpan mRemainingtime; 

    public Action mTimerFinish;
    [SerializeField] private TextMeshProUGUI mTimerText;
    private void Start()
    {
        mTimerInProgress = false;
    }
    private void Update()
    {
        if (mTimerInProgress == true)
        {
            timerManager();        
        }
    }
    public void startChallengeTimer() //call to start timer **once you compete the challenge**
    {
        TimeSpan duration = new TimeSpan(23, 59, 59);
        mTimerEnd = DateTime.Now.Add(duration);
        mTimerInProgress = true;
    }
    private void timerManager() //determining how and when the timer goes down
    {
        if(mTimerInProgress)
        {
            mRemainingtime = mTimerEnd - DateTime.Now;
            if (mRemainingtime.TotalSeconds <= 0)
            {
                mRemainingtime = TimeSpan.Zero;
                mTimerInProgress = false;
                mTimerFinish?.Invoke();
            }
            if (mTimerText != null)
            {
                mTimerText.text = string.Format("{0:D2}:{1:D2}:{2:D2}", mRemainingtime.Hours, mRemainingtime.Minutes, mRemainingtime.Seconds);
            }

        }
    }
    public string GetFormattedTime()
    {
        if (!mTimerInProgress) return "00:00:00";
        return $"{mRemainingtime.Hours:D2}:{mRemainingtime.Minutes:D2}:{mRemainingtime.Seconds:D2}";
    }
}
