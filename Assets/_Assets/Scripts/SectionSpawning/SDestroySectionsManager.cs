using UnityEngine;
public class SDestroySectionsManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("DestroySection") || other.gameObject.CompareTag("Coin") || other.gameObject.CompareTag("HitOBJ"))
        {
            Destroy(other.gameObject);
        }
    }
}