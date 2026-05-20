using UnityEngine;

public class CameraController : MonoBehaviour
{

    private Transform target;
    public Transform clampMin, clampMax;
    private Camera cam;
    private float halfWidth, halfHeight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = FindFirstObjectByType<PlayerController>().transform;

        // remove da herança da camera para não acompanhar seu movimento
        if (clampMin != null) clampMin.SetParent(null);
        if (clampMax != null) clampMax.SetParent(null);

        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (target == null) return;

        // enquadramento da camera (recalculado para suportar mudanças de resolução)
        halfHeight = cam.orthographicSize;
        halfWidth = cam.orthographicSize * cam.aspect;

        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

        if (clampMin != null && clampMax != null)
        {
            // limita o movimento da câmera
            targetPosition.x = Mathf.Clamp(targetPosition.x, clampMin.position.x + halfWidth, clampMax.position.x - halfWidth);
            targetPosition.y = Mathf.Clamp(targetPosition.y, clampMin.position.y + halfHeight, clampMax.position.y - halfHeight);
        }

        transform.position = targetPosition;
    }
}
