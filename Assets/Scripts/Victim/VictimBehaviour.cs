using UnityEngine;

public class VictimBehaviour : MonoBehaviour
{
    [SerializeField] private AudioSource VictimAudioSource;
    [SerializeField] private AudioClip VictimHurtSound;
    [Header("Balloon")]
    [SerializeField] private float stopDistance = 0.5f;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float turnSpeed = 5f;

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
