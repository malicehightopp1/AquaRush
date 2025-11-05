using UnityEngine;

public class SLoadCharacter : MonoBehaviour
{
    [SerializeField] GameObject[] mCharacterPrefabs;
    [SerializeField] Transform mSpawnPoint;
    private void Start()
    {
        int mSelectedCharacter = PlayerPrefs.GetInt("SelectedCharacter");
        GameObject prefab = mCharacterPrefabs[mSelectedCharacter];
        GameObject clone = Instantiate(prefab, mSpawnPoint.position, Quaternion.identity);
        FindAnyObjectByType<SPauseManager>().SetPlayer(prefab.GetComponent<SPlayer>());
    }
}
