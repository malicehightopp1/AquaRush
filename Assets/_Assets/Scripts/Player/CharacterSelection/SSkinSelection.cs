using UnityEngine;
using UnityEngine.SceneManagement;

public class SSkinSelection : MonoBehaviour
{
    [SerializeField] private GameObject[] mCharacters;
    private GameObject mCurrentSelectedSkin;
    [SerializeField] private int mSelectedCharacter = 0;
<<<<<<< HEAD

    private Animation mIdleAnimation;
=======
>>>>>>> b34aba7ec8f3571ac5d389ddadbc2c699825478a
    public void Start()
    {
        mSelectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", mSelectedCharacter);
        mCharacters[mSelectedCharacter].SetActive(true);
<<<<<<< HEAD
        mIdleAnimation = mCharacters[mSelectedCharacter].GetComponent<Animation>();
        UpdateAnimations();
=======
>>>>>>> b34aba7ec8f3571ac5d389ddadbc2c699825478a
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
