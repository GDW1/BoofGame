using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public GameObject player;
    private Transform playerTransform;
    private Transform transform;
    private Camera camera;
    public float dampTime = 0.15f;
     private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        transform = gameObject.GetComponent<Transform>();
        camera = gameObject.GetComponent<Camera>();
        playerTransform = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
            // Rotate the camera every frame so it keeps looking at the target
             Vector3 point = camera.WorldToViewportPoint(playerTransform.position);
             Vector3 delta = playerTransform.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
             Vector3 destination = transform.position + delta;
             transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);

    }
}
