using UnityEngine;

public class StreetMovement : MonoBehaviour
{
    [SerializeField] private Transform human;
    [SerializeField] private Transform streetEnd;
    [SerializeField, Min(0f)] private float speed = 0.5f;

    private bool finished;

    private void Start()
    {
        if (human == null || streetEnd == null)
        {
            Debug.LogError(
                "Assign Human and Street End in the Inspector.", this);
            enabled = false;
        }
    }

    private void Update()
    {
        if (finished)
            return;

        float remainingDistance =
            streetEnd.position.z - human.position.z;

        if (remainingDistance <= 0f)
        {
            FinishWalk();
            return;
        }

        float movement = Mathf.Min(
            speed * Time.deltaTime,
            remainingDistance);

        transform.position += Vector3.back * movement;

        if (movement >= remainingDistance)
            FinishWalk();
    }

    private void FinishWalk()
    {
        finished = true;
        Debug.Log("The human reached the end of the street!", this);
    }
}