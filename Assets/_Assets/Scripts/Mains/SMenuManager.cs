using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SMenuManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] Button mStartButton, mQuitButton, mMainMenuButton, mPlayAgainButton;

    [SerializeField] SSkinSelection mSkinSelection;
    private SCoinManager mCoinManager;
    private SDistanceManager mDistanceManager;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        mDistanceManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SDistanceManager>();
        mCoinManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SCoinManager>();

        mStartButton?.onClick.AddListener(StartOnClick);
        mQuitButton?.onClick.AddListener(QuitOnClick);
        mMainMenuButton?.onClick.AddListener(MainMenuOnClick);
        mPlayAgainButton?.onClick.AddListener(PlayAgain);
    }
    private void StartOnClick()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1.0f;
        Cursor.visible = false;
        SceneManager.LoadScene(1);
    }
    private void QuitOnClick()
    {
        mCoinManager.SaveCoins();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Debug.Log("Quitting game");
        Application.Quit();
    }
    private void MainMenuOnClick()
    {
        mDistanceManager.GetSaveDistance();
        mCoinManager.SaveCoins();
        Debug.Log("MainMenu");
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        SceneManager.LoadScene(0);

        mDistanceManager.GetLoadDistance();
        mCoinManager.LoadCoins();

        mCoinManager.LoadCoins();
    }
    private void PlayAgain()
    {
        mCoinManager.SaveCoins();
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1.0f;
        Cursor.visible = false;
        SceneManager.LoadScene(1);
    }
}
