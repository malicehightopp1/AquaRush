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

    private SChallenges mChallenges;
    public void Start()
    {
        mProgressBar.value = mChallenges.mCurrentValue;
    }
    public void Setup(SChallenges challenges)
    {
        mChallenges = challenges;
        if(challenges.mChallengeType == ChallengeType.CollectCoins) //changing default value to certain value 
        {
            challenges.mCompletevalue = 10;
        }
        if (challenges.mChallengeType == ChallengeType.ReachDistance)
        {
            challenges.mCompletevalue = 50;
        }
        if(challenges.mTimer != null && challenges.mTimer.mTimerInProgress)
        {
            InvokeRepeating(nameof(UpdateTimerText), 0f, 1f); //update UI every second if timer is in progress
        }
        UpdateUI();
    }
    private void Update()
    {
        if (mChallenges != null)
        {
            UpdateUI();
        }
    }
    private void UpdateUI()
    {
        mNameText.text = mChallenges.name;
        mDecriptionText.text = mChallenges.mChallengeDescription;
        mProgressBar.value = mChallenges.mCurrentValue;
        mProgressBar.maxValue = mChallenges.mCompletevalue;
    }
    public void ChallengeDoneUiUpdate()
    {
        mCompletedOverlay.SetActive(true);
        mProgressBar.value = 1f; // full progress
    }
    public void ResetUI()
    {
        mCompletedOverlay.SetActive(false);
        mProgressBar.value = 0f; // reset progress
    }
    private void UpdateTimerText()
    {
        if (mChallenges.mTimer != null && mChallenges.mTimer.mTimerInProgress)
        {
            mTimerText.text = mChallenges.mTimer.GetFormattedTime();
        }
    }
}
