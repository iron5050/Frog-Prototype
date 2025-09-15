using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("refrence")]
    public Transform orientation;
    public Transform player;
    public Transform playerobj;
    public Rigidbody rb;

    public float rotationspeed;

    private void Start()
    {
        //make cursor invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    //this makes the player mesh face direction of arrow keys based on where the camera is looking.
    private void Update()
    {
        //rotation orientation
        Vector3 viewDir = player.position - new Vector3(transform.position.x, transform.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        //rotate player object
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (inputDir != Vector3.zero)
            playerobj.forward = Vector3.Slerp(playerobj.forward, inputDir.normalized, Time.deltaTime * rotationspeed);
    }
}
