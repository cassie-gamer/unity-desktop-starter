using UnityEngine;

// Add this to a small sphere to make it spin as a pickup
public class PickupSpinner : MonoBehaviour
{
    public float spinSpeed = 90f;

    void Update()
    {
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        // When the player touches it, add score and hide it
        // Make sure the pickup has "Is Trigger" checked on its collider
        // and the player has a Rigidbody + Collider
        if (ScoreManager.Instance != null)
            ScoreManager.Instance.AddPoint();
        gameObject.SetActive(false);
    }
}
