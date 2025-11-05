using System.Collections.Generic;
using UnityEngine;

public class SChallengeManager : MonoBehaviour
{
    public List<SChallenges> challenges = new List<SChallenges>();
    [SerializeField] private Transform mUiSpawnTransform;
    [SerializeField] private GameObject mUiSpawnPrefab;

    [Header("References")]
    private SCoinManager mCoinManager;
    private void Start()
    {
        mCoinManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SCoinManager>();
        LoadChallenge();
    }
    private void LoadChallenge()
    {
        foreach(Transform Prefabs in mUiSpawnTransform)
        {
            Destroy(Prefabs.gameObject);
        }
        foreach(var challenge in challenges)
        {
            GameObject ui = Instantiate(mUiSpawnPrefab, mUiSpawnTransform);
            var uiHandler = ui.GetComponent<SChallengeUI>();
            uiHandler.Setup(challenge);
            
            if (challenge.mTimer == null)
            {
                GameObject TimerGo = new GameObject($"{challenge.mChallengeName}_Timer");
                challenge.mTimer = TimerGo.AddComponent<SChallengeTimer>();       
            }
            challenge.mTimer.mTimerFinish += () =>
            {
                challenge.ResetProgress();
                uiHandler.ResetUI();
                uiHandler.ChallengeDoneUiUpdate();
            };
        }
    }
    public void AddProgressToType(ChallengeType type, float amount)
    {
        foreach (var challenge in challenges)
        {
            if(challenge.mChallengeType == type && !challenge.mIsCompleted)
            {
                challenge.AddProgress(amount);

                if(challenge.mIsCompleted)
                {
                    mCoinManager.CurrentCoins += challenge.mRewardCoins; //reward for completing challenge

                    if(challenge.mTimer != null && !challenge.mTimer.mTimerInProgress)
                    {
                        challenge.mTimer.startChallengeTimer();
                    }
                }
            }
        }
        LoadChallenge();
    }
}
