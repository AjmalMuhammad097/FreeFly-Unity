using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
public class CameraEdgeCollider : MonoBehaviour
{
    private Camera cameraMain;
    private EdgeCollider2D edgeCollider;

    private void Start()
    {
        cameraMain = GetComponentInParent<Camera>();
        edgeCollider = GetComponent<EdgeCollider2D>();
        DrawEdgeCollider();
    }

    private void DrawEdgeCollider()
    {
        var topLeft = cameraMain.ScreenToWorldPoint(new Vector3(0, Screen.height, cameraMain.transform.position.z));
        var topRight = cameraMain.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cameraMain.transform.position.z));
        var bottomRight = cameraMain.ScreenToWorldPoint(new Vector3(Screen.width, 0, cameraMain.transform.position.z));
        var bottomLeft = cameraMain.ScreenToWorldPoint(new Vector3(0, 0, cameraMain.transform.position.z));

        //edgeCollider.points = new Vector2[] { topLeft, topRight, bottomRight, bottomLeft, topLeft }; // For squared collider
        edgeCollider.points = new Vector2[] { bottomLeft, topLeft, topRight, bottomRight };
    }

}
