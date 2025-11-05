using UnityEngine;

public class SObjectOtherDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HitOBJ"))
        {
            Destroy(this.gameObject);
        }
    }
}
