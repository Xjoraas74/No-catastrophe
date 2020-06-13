using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 offset;
    public Camera cam;

    void Start()
    {
        cam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = transform.position + offset;
    }
}
