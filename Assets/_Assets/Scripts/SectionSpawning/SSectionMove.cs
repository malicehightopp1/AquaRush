using UnityEngine;
public class SSectionMove : MonoBehaviour
{
    SSpawningManager mSpawningManager;
    private void Start()
    {
        mSpawningManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SSpawningManager>();
    }
    public void Update()
    {
        SectionMovement();
    }
    private void SectionMovement()
    {
        transform.position += new Vector3(0, 0, -mSpawningManager.MoveSpeed) * Time.deltaTime;
    }
}
