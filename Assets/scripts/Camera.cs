using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Transform coin;
    public float smoothTime = 0.3f;
    public float minZoom = 5f;
    public float maxZoom = 10f;
    public float zoomLimiter = 5f;

    private Vector3 velocity = Vector3.zero;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (player == null || coin == null)
            return;

        //PUNTO MEDIO ENTRE COIN Y PLAYES
        Vector3 centerPoint = (player.position + coin.position) / 2f;
        centerPoint.z = transform.position.z; 

        transform.position = Vector3.SmoothDamp(transform.position, centerPoint, ref velocity, smoothTime);

        float distance = Vector3.Distance(player.position, coin.position);
        float targetZoom = Mathf.Lerp(minZoom, maxZoom, distance / zoomLimiter);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime);
    }
}
