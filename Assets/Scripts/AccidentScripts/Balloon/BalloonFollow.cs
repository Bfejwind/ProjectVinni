using UnityEngine;

public class BalloonFollow : MonoBehaviour
{
    [SerializeField] private VictimBehaviour victimScript;
    void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent(out VictimBehaviour victimscript);
        if (victimscript != null)
        {
            victimScript = victimscript;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (victimScript != null)
        {
            victimScript.Hypnotised(transform);
        }
    }
}
