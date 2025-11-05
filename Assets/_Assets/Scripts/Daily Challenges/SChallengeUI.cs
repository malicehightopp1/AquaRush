using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SChallengeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI mNameText;
    [SerializeField] private TextMeshProUGUI mDecriptionText;
    [SerializeField] private Slider mProgressBar;

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
            challenges.mCompletevalue = 100;
        }
        if (challenges.mChallengeType == ChallengeType.ReachDistance)
        {
            challenges.mCompletevalue = 500;
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
        mNameText.text = "Challenge Complete!";
    }
}
