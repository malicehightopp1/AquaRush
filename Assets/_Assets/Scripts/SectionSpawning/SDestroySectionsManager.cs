using UnityEngine;
public class SDestroySectionsManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("DestroySection"))
        {
            Destroy(other.gameObject);
            Debug.Log($"Trigger hit {other.gameObject.name}");
        }
    }
}
