using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SMenuManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] Button mStartButton, mQuitButton, mMainMenuButton, mPlayAgainButton;

    [SerializeField] SSkinSelection mSkinSelection;
    private SCoinManager mCoinManager;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

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
        mCoinManager.SaveCoins();
        Debug.Log("MainMenu");
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        SceneManager.LoadScene(0);
        mCoinManager.LoadCoins();
<<<<<<< HEAD
    }
    private void PlayAgain()
    {
        mCoinManager.SaveCoins();
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1.0f;
        Cursor.visible = false;
        SceneManager.LoadScene(1);
=======
>>>>>>> 62b0d270a1dad68aa1ab653d35e6fe36ac6a0234
    }
}
