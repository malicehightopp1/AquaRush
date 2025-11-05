using UnityEngine;
public enum ChallengeType
{
    CollectCoins = 0,
    ReachDistance
}
[CreateAssetMenu(fileName = "challenge", menuName = "Create challenge")]
public class SChallenges : ScriptableObject
{
    [Header("Quest variables")]
    public string mChallengeName;
    public string mChallengeDescription;
    public ChallengeType mChallengeType;

    [Header("Quest Progress")]
    public int mCompletevalue = 100;
    public float mCurrentValue = 0;

    [Header("Rewards")]
    public int mRewardCoins = 50;
    public bool mIsCompleted = false;

    [HideInInspector]
    public SChallengeTimer mTimer;
    public void ResetProgress()
    {
        mCurrentValue = 0;
        mIsCompleted = false;
    }
    public void AddProgress(float amount)
    {
        if(mIsCompleted) return;

        mCurrentValue += amount;
        if(mCurrentValue >= mCompletevalue)
        {
            mCurrentValue = mCompletevalue;
            mIsCompleted = true;
            Debug.Log($"challenge completed: {mChallengeName}");
        }
    }
}
