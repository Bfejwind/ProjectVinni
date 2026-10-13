using UnityEngine;

public class FallingObj : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Victim"))
        {
            
        }
    }
}
