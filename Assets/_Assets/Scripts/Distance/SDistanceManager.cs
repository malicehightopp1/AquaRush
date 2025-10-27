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
    private void Start()
    {
        mDistanceText = GameObject.FindGameObjectWithTag("DistanceText")?.GetComponent<TextMeshProUGUI>();
        mMaxDistanceText = GameObject.FindGameObjectWithTag("MaxDistanceText")?.GetComponent<TextMeshProUGUI>();
<<<<<<< HEAD
=======
        mSpawningManager = GameObject.FindGameObjectWithTag("GameController")?.GetComponent<SSpawningManager>();
>>>>>>> 1bdc505 (Main menu rework and general bug fixes)
        if(SceneManager.GetActiveScene().name == "MainMenu_Scene")
        {
            LoadDistance();
        }
    }
    private void Update()
    {
        SpeedChange();
        if(SceneManager.GetActiveScene().name != "MainMenu")
        {
            PlayerDistance();
        }
    }
    private void PlayerDistance() //handling the players distance 
    {
        mDistance += (1 * 3f) * Time.deltaTime;
        mDistanceText?.SetText($"Distance : {mDistance.ToString("F2")}");

        if(mDistance > mMaxDistance) //updating when the distance is higher than the max distance
        {
            mMaxDistance = mDistance;
        }
    }
    public void SaveDistance()
    {
        if (mDistance > mMaxDistance)
        {
            PlayerPrefs.SetFloat("Distance", mMaxDistance);
            PlayerPrefs.Save();
            Debug.Log($"New Max Distance Achieved: {mMaxDistance}");
        }
    }
    public void LoadDistance()
    {
        mMaxDistance = PlayerPrefs.GetFloat("Distance", 0f);
        Debug.Log($"Loading Max Distance: {mMaxDistance}"); 
        mMaxDistanceText.text = "Max Distance : " + mMaxDistance.ToString("F2");
    }
    private void SpeedChange()
    {
        if (mDistance >= mNextSpeedChange)
        {
            Debug.Log($"Current Distance is: {mDistance} and Current Speed if: {mSpawningManager.MoveSpeed}");
            mSpawningManager.MoveSpeed += 5f;
            mNextSpeedChange += 400;
        }
    }
}