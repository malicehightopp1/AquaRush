using UnityEngine;
using UnityEngine.SceneManagement;

public class SSkinSelection : MonoBehaviour
{
    [SerializeField] private GameObject[] mCharacters;
    private GameObject mCurrentSelectedSkin;
    [SerializeField] private int mSelectedCharacter = 0;

    public void Start()
    {
        mSelectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", mSelectedCharacter);
        Debug.Log($"Selected boat is: {mSelectedCharacter}");
        mCharacters[mSelectedCharacter].SetActive(true);
    }
    public void NextCharacter()
    {
        mCharacters[mSelectedCharacter].SetActive(false);
        mSelectedCharacter = (mSelectedCharacter + 1) % mCharacters.Length;
        mCharacters[mSelectedCharacter].SetActive(true);
    }
    public void PreviousCharacter()
    {
        mCharacters[mSelectedCharacter].SetActive(false);
        mSelectedCharacter--;
        if(mSelectedCharacter < 0)
        {
            mSelectedCharacter += mCharacters.Length;
        }
        mCharacters[mSelectedCharacter].SetActive(true);
    }
    public void SavePlayerSkin()
    {
        mCurrentSelectedSkin = mCharacters[mSelectedCharacter];
        Debug.Log($"Selected skin : {mCurrentSelectedSkin.gameObject.name}");
        PlayerPrefs.SetInt("SelectedCharacter", mSelectedCharacter);
    }
}
