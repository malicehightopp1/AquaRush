using System;
using TMPro;
using UnityEngine;
public class SChallengeTimer : MonoBehaviour
{
    public bool mTimerInProgress;
    private DateTime mTimerEnd;
    private TimeSpan mRemainingtime; 

    [SerializeField] TextMeshProUGUI mTestText;
    public Action mTimerFinish;
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
    public void startChallengeTimer(SChallenges challenge) //call to start timer **once you compete the challenge**
    {
        TimeSpan duration = new TimeSpan(0, 0, 10);
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
                mTestText.text = "";

                mTimerFinish?.Invoke();
            }
            else
            {
                mTestText.text = $"{mRemainingtime.Hours:D2}:{mRemainingtime.Minutes:D2}:{mRemainingtime.Seconds:D2}";
            }
        }
    }
}
