using System;
using UnityEngine;

public class FallingObj : MonoBehaviour
{
    private Rigidbody potRb;
    [SerializeField] private AudioSource PotAudioSource;
    [SerializeField] private AudioClip PotFallSound;
    [SerializeField] private AudioClip PotHitSound;
    private void Start()
    {
        potRb = GetComponentInChildren<Rigidbody>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Victim"))
        {
            potRb.isKinematic = false;
            Debug.Log("Falling");
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out VictimBehaviour victim))
        {
            victim.PlayerHurt();
        }
    }
}
