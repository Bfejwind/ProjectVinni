using UnityEngine;

public class KidShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private float shootingInterval = 5f;
    private float shootingTimer = 0f;
    [SerializeField] private float shootingForce = 500f;
    [SerializeField] private Transform playerTransform;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Victim"))
        {
            Debug.Log("Player detected");
            Vector3 direction = playerTransform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(direction);
            shootingTimer += Time.deltaTime;
            if (shootingTimer >= shootingInterval)
            {
                Shoot();
                shootingTimer = 0f;
            }
        }
    }

    private void Shoot()
    {
        GameObject projectile = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
        projectile.GetComponent<Rigidbody>().AddForce(transform.forward * shootingForce);
    }
    

}
