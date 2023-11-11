using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target to follow (usually the player).
    public Vector3 offset = new Vector3(0f, 0f, -10f); // Offset from the target.

    // Smoothness of camera follow. Higher values make it smoother, but too high may cause lag.
    public float smoothSpeed = 5.0f;

    void Start()
    {
        transform.position = offset;
    }

    void LateUpdate()
    {
        if (target != null)
        {
            // if (Vector3.Distance(transform.position, target.position + offset) < smoothSpeed) return;
            // Vector3 desiredPosition = target.position + offset;
            // Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            Vector3 desiredPosition = target.position + offset;
            float lerpedX = Mathf.Lerp(transform.position.x, desiredPosition.x, smoothSpeed * Time.deltaTime);
            Vector3 lerpedVector = new Vector3(lerpedX, transform.position.y, transform.position.z);
            transform.position = lerpedVector;
        }
    }
}
