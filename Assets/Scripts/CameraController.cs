using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;
    public float pitch = 2f;
    public float yawSpeed = 100f;

    private float currentZoom = 10f;
    private float currentYaw = 0f;

    // Update is called once per frame
    void Update()
    {
        //Zoom
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        //Kamerans rotation
        currentYaw -=  Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }

    void LateUpdate () {
        //Zoom
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);

        //Kamerans rotation
        transform.RotateAround(target.position, Vector3.up, currentYaw);
	}
}
