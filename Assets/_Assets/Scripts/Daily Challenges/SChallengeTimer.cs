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

    private string mSaveKey;
    private void Start()
    {
        mTimerInProgress = false;
        if(string.IsNullOrEmpty(mSaveKey))
        {
            mSaveKey = gameObject.name + "_TimerEnd"; //fallback if init doesnt get called
        }
        loadTimer();
    }
    #region Saving/loading
    private void loadTimer()
    {
        if (PlayerPrefs.HasKey(mSaveKey))
        {
            long savedTimer = Convert.ToInt64 (PlayerPrefs.GetString(mSaveKey));
            mTimerEnd = DateTime.FromBinary(savedTimer);
            mRemainingtime = mTimerEnd - DateTime.Now;
            if(mRemainingtime.TotalSeconds > 0)
            {
                mTimerInProgress = true;
            }
            else
            {
                mTimerInProgress = false;
                PlayerPrefs.DeleteKey(mSaveKey);
                PlayerPrefs.Save();
                mTimerFinish?.Invoke();
            }
        }
    }
    private void SaveTimer()
    {
        long endTimeBinary = mTimerEnd.ToBinary(); //converts info into longer integer so it can be stored because player prefs can only store basic info
        PlayerPrefs.SetString(mSaveKey, endTimeBinary.ToString()); //saves in player prefs under a custom key
        PlayerPrefs.Save();
    }
    public void Init(string uniqueKey) //assigns a unique key for saving 
    {
        mSaveKey = uniqueKey + "_TimerEnd";
    }
    #endregion
    #region TimerManagment
    private void Update()
    {
        if (mTimerInProgress == true)
        {
            timerManager();        
        }
    }
    public void startChallengeTimer() //call to start timer **once you complete the challenge**
    {
        TimeSpan duration = new TimeSpan(0, 1, 0);
        mTimerEnd = DateTime.Now.Add(duration);
        mTimerInProgress = true;

        SaveTimer();
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
        return $"Next challenge in: {mRemainingtime.Hours:D2}:{mRemainingtime.Minutes:D2}:{mRemainingtime.Seconds:D2}";
    }
    #endregion
    private void OnApplicationQuit()
    {
        SaveTimer();
    }
}
