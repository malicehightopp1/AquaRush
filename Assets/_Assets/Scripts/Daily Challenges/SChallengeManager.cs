using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SChallengeManager : MonoBehaviour
{
    public List<SChallenges> challenges = new List<SChallenges>();
    [SerializeField] private Transform mUiSpawnTransform;
    [SerializeField] private GameObject mUiSpawnPrefab;
    private void Start()
    {
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
        }
    }
    public void AddProgressToType(ChallengeType type, int amount)
    {
        foreach (var challenge in challenges)
        {
            if(challenge.mChallengeType == type && !challenge.mIsCompleted)
            {
                challenge.AddProgress(amount);
            }
        }
    }
}
