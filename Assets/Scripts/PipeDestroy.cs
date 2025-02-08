using UnityEngine;

public class PipeDestroy : MonoBehaviour
{
    private Camera mainCamera;

    public void SetCamera(Camera cam)
    {
        mainCamera = cam;
    }

    void Update()
    {
        if (mainCamera == null) return; // Handle the case where the camera is not set

        Vector3 viewportPos = mainCamera.WorldToViewportPoint(transform.position);

        // Check if the pipe is outside the left edge of the camera view
        if (viewportPos.x < 0)
        {
            Destroy(gameObject); // Destroy the pipe
        }
    }
}
