using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    private Transform player;
    private Transform dolly;
    private Transform cam;

    public float distance = 4;
    public float mouseSense = 2.5f;
    public float mouseScrollSense = 1.0f;

    private float hRot;
    private float vRot;
    private int vRotMax = 60;
    private int vRotMin = -20;

    private float distMax = 10.0f;
    private float distMin = 1.2f;


    // Use this for initialization
    void Start () {
        dolly = this.transform;
        cam = transform.FindChild("Camera");
        player = GameObject.FindGameObjectWithTag("Player").transform;
	    dolly.position = player.position;
	}
	
	// Update is called once per frame
	void Update () {
        dolly.position = player.position;
        dolly.rotation = player.rotation;

        if (Input.GetMouseButton(1))
        {
            hRot += Input.GetAxis("Mouse X") * mouseSense;
            vRot -= Input.GetAxis("Mouse Y") * mouseSense;
        }

        vRot = Mathf.Clamp(vRot, vRotMin, vRotMax);

        distance -= Input.GetAxis("Mouse ScrollWheel") * mouseScrollSense;
        distance = Mathf.Clamp(distance, distMin, distMax);

        dolly.rotation = Quaternion.Euler(vRot, hRot, 0);

        cam.localPosition = new Vector3(0, 0, -distance);
    }
}
