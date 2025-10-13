using UnityEngine;
public class SDestroySectionsManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("DestroySection"))
        {
            Debug.Log($"Destroying section");
            Destroy(other.gameObject);
        }
    }
}
