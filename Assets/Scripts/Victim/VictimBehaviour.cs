using UnityEngine;

public class VictimBehaviour : MonoBehaviour
{
    [Header("PlayerHurt")]
    public float knockbackForce = 10f;
    public float upwardForce = 5f;
    private Rigidbody victimRb;
    [SerializeField] private AudioSource VictimAudioSource;
    [SerializeField] private AudioClip VictimHurtSound;
    [Header("Balloon")]
    [SerializeField] private float stopDistance = 0.5f;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float turnSpeed = 5f;
    void Awake()
    {
        victimRb = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Hazard")) return;

        // Push away from the hazard.
        Vector3 direction =
            transform.position - collision.transform.position;

        direction.y = 0f;
        direction.Normalize();

        Vector3 force =
            direction * knockbackForce +
            Vector3.up * upwardForce;

        victimRb.AddForce(force, ForceMode.Impulse);
    }

    public void PlayerHurt()
    {
        //VictimAudioSource.PlayOneShot(VictimHurtSound);
    }
    public void Hypnotised(Transform balloon)
    {
        Debug.Log("Hypnotised");
        if (balloon == null) return;
        Vector3 direction = (balloon.position - transform.position);
        float distance = direction.magnitude;
        direction.Normalize();
        if (distance <= stopDistance) return;
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            turnSpeed * Time.deltaTime
        );
        if (distance > stopDistance)
        {
            float step = Mathf.Min(
                moveSpeed * Time.deltaTime,
                distance - stopDistance
            );
            transform.position += direction * step;
        }
    }

}
