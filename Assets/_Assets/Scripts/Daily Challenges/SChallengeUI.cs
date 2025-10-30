using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SChallengeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI mNameText;
    [SerializeField] private TextMeshProUGUI mDecriptionText;
    [SerializeField] private Slider mProgressBar;

    private SChallenges mChallenges;
    public void Setup(SChallenges challenges)
    {
        mChallenges = challenges;
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
        mProgressBar.value = mChallenges.GetProgressPercent();
    }
}
