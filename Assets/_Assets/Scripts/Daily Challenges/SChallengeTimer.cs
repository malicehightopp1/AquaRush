using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SChallengeTimer : MonoBehaviour
{
    private bool mTimerInProgress;
    private DateTime mTimerEnd;
    private TimeSpan mRemainingtime;

    [SerializeField] Button mTestButton;
    [SerializeField] TextMeshProUGUI mTestText;
    private void Start()
    {
        mTimerInProgress = false;
        mTestButton.onClick.AddListener(startChallenegTimer);
    }
    private void Update()
    {
        timerManager();
    }
    private void startChallenegTimer() //call to start timer **once you compete the challenge**
    {
        TimeSpan duration = new TimeSpan(23, 59, 59);
        mTimerEnd = DateTime.Now.Add(duration);
        mTimerInProgress = true;
    }
    private void timerManager() //determining how and when the timer goes down
    {
        if (mTimerInProgress)
        {
            mRemainingtime = mTimerEnd - DateTime.Now;
            if (mRemainingtime.TotalSeconds <= 0)
            {
                mRemainingtime = TimeSpan.Zero;
                mTimerInProgress = false;
                mTestText.text = "Timer Done! ";
            }
            else
            {
                mTestText.text = $"{mRemainingtime.Hours:D2}:{mRemainingtime.Minutes:D2}:{mRemainingtime.Seconds:D2}";
            }
        }
    }
}
