using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SDistanceManager : MonoBehaviour
{
    [Header("Distance Settings")]
    [SerializeField] float mDistance = 0;
    private float mMaxDistance;
    private int mNextSpeedChange = 400;

    [Header("Components")]
    private TextMeshProUGUI mDistanceText;
    private TextMeshProUGUI mMaxDistanceText;

    [Header("References")]
    private SSpawningManager mSpawningManager;
    public void GetSaveDistance() => SaveDistance();
    public void GetLoadDistance() => LoadDistance();
    private void Start()
    {
        mDistanceText = GameObject.FindGameObjectWithTag("DistanceText")?.GetComponent<TextMeshProUGUI>();
        mMaxDistanceText = GameObject.FindGameObjectWithTag("MaxDistanceText")?.GetComponent<TextMeshProUGUI>();
        mSpawningManager = GameObject.FindGameObjectWithTag("GameController")?.GetComponent<SSpawningManager>();
        if(SceneManager.GetActiveScene().name == "MainMenu_Scene")
        {
            LoadDistance();
        }
    }
    private void Update()
    {
        SpeedChange();
        if(SceneManager.GetActiveScene().name != "MainMenu_Scene")
        {
            PlayerDistance();
        }
    }
    private void PlayerDistance() //handling the players distance 
    {
        mDistance += (1 * 3f) * Time.deltaTime;
        mDistanceText?.SetText($"Distance : {mDistance.ToString("F2")}");
        FindFirstObjectByType<SChallengeManager>().AddProgressToType(ChallengeType.ReachDistance, (1 * 3f) * Time.deltaTime);
    }
    private void SaveDistance() //not currently doing this
    {
        LoadDistance();
        if(mDistance > mMaxDistance) //updating when the distance is higher than the max distance
        {
            mMaxDistance = mDistance;
            Debug.Log($"New Max Distance Achieved: {mMaxDistance}");
            PlayerPrefs.SetFloat("Distance", mMaxDistance);
            PlayerPrefs.Save();
        }
    }
    private void LoadDistance() //currently loads the distance 
    {
        mMaxDistance = PlayerPrefs.GetFloat("Distance", 0f);
        Debug.Log($"Loading Max Distance: {mMaxDistance}");
        mMaxDistanceText?.SetText($"Distance : {mMaxDistance.ToString("F2")}");
    }
    private void SpeedChange() //changes speed based on distance the player has got to
    {
        if (mDistance >= mNextSpeedChange)
        {
            Debug.Log($"Current Distance is: {mDistance} and Current Speed if: {mSpawningManager.MoveSpeed}");
            mSpawningManager.MoveSpeed += 5f;
            mNextSpeedChange += 400;
        }
    }
}