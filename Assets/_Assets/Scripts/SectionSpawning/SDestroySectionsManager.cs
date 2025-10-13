using UnityEngine;
public class SDestroySectionsManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger is working");
        if(other.gameObject.CompareTag("DestroySection"))
        {
            Destroy(other.gameObject);
            Debug.Log($"Trigger hit {other.gameObject.name}");
            Debug.Log($"Destroying section");
        }
    }
}
