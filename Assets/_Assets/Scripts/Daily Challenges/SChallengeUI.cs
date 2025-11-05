using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SChallengeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI mNameText;
    [SerializeField] private GameObject mCompletedOverlay;
    [SerializeField] private TextMeshProUGUI mDecriptionText;
    [SerializeField] private Slider mProgressBar;
    [SerializeField] private TextMeshProUGUI mTimerText;
    private bool mDone = false;

    private SChallenges mChallenges;
    public void Start()
    {
        mCompletedOverlay.SetActive(false);
        if(!mChallenges.mTimer.mTimerInProgress)
        {
            mTimerText.text = "";
        }
    }
    public void Setup(SChallenges challenges)
    {
        CancelInvoke(nameof(UpdateTimerText));
        mDone = false;
        mChallenges = challenges;
        if(challenges.mChallengeType == ChallengeType.CollectCoins) //changing default value to certain value 
        {
            challenges.mCompletevalue = 10;
        }
        if (challenges.mChallengeType == ChallengeType.ReachDistance)
        {
            challenges.mCompletevalue = 100;
        }
        if(challenges.mTimer != null && challenges.mTimer.mTimerInProgress && mDone == false)
        {
            InvokeRepeating(nameof(UpdateTimerText), 0f, 1f); //update UI every second if timer is in progress
            mDone = true;
        }
        UpdateUI();
    }
    private void UpdateUI()
    {
        if(mChallenges == null) return;
        mNameText.text = mChallenges.name;
        mDecriptionText.text = mChallenges.mChallengeDescription;
        mProgressBar.value = mChallenges.mCurrentValue;
        mProgressBar.maxValue = mChallenges.mCompletevalue;
    }
    public void ChallengeDoneUiUpdate()
    {
        mProgressBar.value = mProgressBar.maxValue; // full progress
    }
    public void ResetUI()
    {
        mProgressBar.value = 0f; // reset progress
        mTimerText.text = "";
    }
    private void UpdateTimerText()
    {
        if (mChallenges.mTimer != null && mChallenges.mTimer.mTimerInProgress)
        {
            mTimerText.text = mChallenges.mTimer.GetFormattedTime();
        }
        else
        {
            CancelInvoke(nameof(UpdateTimerText));
            mDone = false;
        }
    }
}
