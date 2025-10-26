using UnityEngine;
using UnityEngine.SceneManagement;

public class SSkinSelection : MonoBehaviour
{
    [SerializeField] private GameObject[] mCharacters;
    private GameObject mCurrentSelectedSkin;
    [SerializeField] private int mSelectedCharacter = 0;

    private Animation mIdleAnimation;
    public void Start()
    {
        mSelectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", mSelectedCharacter);
        mCharacters[mSelectedCharacter].SetActive(true);
        mIdleAnimation = mCharacters[mSelectedCharacter].GetComponent<Animation>();
        UpdateAnimations();
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
    private void Update()
    {
        UpdateAnimations();
    }
    private void UpdateAnimations()
    {
        mIdleAnimation.Play();
    }
}
