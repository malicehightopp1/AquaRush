using UnityEngine;
using UnityEngine.SceneManagement;

public class SSkinSelection : MonoBehaviour
{
    [SerializeField] private GameObject[] mCharacters;
    [SerializeField] private int mSelectedCharacter = 0;

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
    public void StartGame()
    {
        PlayerPrefs.SetInt("SelectedCharacter", mSelectedCharacter);
    }
}
