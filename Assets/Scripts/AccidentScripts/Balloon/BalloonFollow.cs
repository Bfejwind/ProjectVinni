using UnityEngine;
using UnityEngine.Splines;

public class BalloonFollow : MonoBehaviour
{
    [SerializeField] private VictimBehaviour victimScript;
    public SplineAnimate balloonSpline;
    void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent(out VictimBehaviour victimscript);
        if (victimscript != null)
        {
            balloonSpline.Play();
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
