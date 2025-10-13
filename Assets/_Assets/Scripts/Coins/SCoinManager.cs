using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class SCoinManager : MonoBehaviour
{
    [Header("Coin management")]
    private int mCurrentCoins = 0;
    private TextMeshProUGUI mCurrentCoinsText;

    [Header("Coin Spawning")]
    [SerializeField] private List<GameObject> mPrefabList;
    private float mzOffset = 0;
    public int CurrentCoins //getter and setter for coins manager
    {
        get { return mCurrentCoins; }
        set
        {
            int delta = value - mCurrentCoins;
            CoinsManager(delta);
        }
    }
    void Start()
    {
        mCurrentCoinsText = GameObject.FindGameObjectWithTag("CoinText").GetComponent<TextMeshProUGUI>();         
        mCurrentCoins = 0;
        mCurrentCoinsText.text = "Coins : " + mCurrentCoins.ToString();
        CoinSpawnManager();
    }
    private void CoinsManager(int CoinsToAdd)
    {
        mCurrentCoins += CoinsToAdd;
        mCurrentCoins = Mathf.Clamp(mCurrentCoins, 0, 10000);
        mCurrentCoinsText.text = "Coins : " + mCurrentCoins.ToString();
    }
    private void CoinSpawnManager() // managing spawning coins
    {
        for(int i = 0; i < 5; i++)
        {
            Vector3 spawnx = new Vector3(Random.Range(1.5f, -1.5f) , 1, Random.Range(25, 100));
            GameObject RandomPrefab = GetRandomObject(mPrefabList);
            GameObject spawnedObject = Instantiate(RandomPrefab, spawnx, Quaternion.identity);
        }
    }
    GameObject GetRandomObject(List<GameObject> list) //picking a random pattern of coins
    {
        int index = Random.Range(0, list.Count);
        return list[index];
    }
    public void CoinSpawnGetter()
    {
        CoinSpawnManager();
    }
}
