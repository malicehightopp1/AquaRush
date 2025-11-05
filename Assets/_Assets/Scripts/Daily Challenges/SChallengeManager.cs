using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SChallengeManager : MonoBehaviour
{
    public List<SChallenges> challenges = new List<SChallenges>();
    [SerializeField] private Transform mUiSpawnTransform;
    [SerializeField] private GameObject mUiSpawnPrefab;

    [Header("References")]
    private SChallengeTimer mTimer;
    private SCoinManager mCoinManager;
    private void Start()
    {
        mTimer = GameObject.FindGameObjectWithTag("GameController").GetComponent<SChallengeTimer>();
        mCoinManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SCoinManager>();
        mTimer.mTimerFinish += StartNewChallenge;
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
            if(challenge.mIsCompleted && !mTimer.mTimerInProgress)
            {
                mTimer.startChallengeTimer(challenge);
                uiHandler.ChallengeDoneUiUpdate();
                mCoinManager.CurrentCoins += challenge.mRewardCoins; //reward for completing challenge
            }
        }
    }
    private void StartNewChallenge()
    {
        if (mTimer.mTimerInProgress == false)
        {
            foreach (var challenge in challenges)
            {
                if (challenge.mIsCompleted)
                {
                    challenge.ResetProgress();
                }
            }
            LoadChallenge();
        }
    }
    public void AddProgressToType(ChallengeType type, float amount)
    {
        foreach (var challenge in challenges)
        {
            if(challenge.mChallengeType == type && !challenge.mIsCompleted)
            {
                challenge.AddProgress(amount);
            }
        }
        LoadChallenge();
    }
}
