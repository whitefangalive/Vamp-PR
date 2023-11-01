using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target to follow (usually the player).
    public Vector3 offset = new Vector3(0f, 0f, -10f); // Offset from the target.

    // Smoothness of camera follow. Higher values make it smoother, but too high may cause lag.
    public float smoothSpeed = 5.0f;

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }
}
