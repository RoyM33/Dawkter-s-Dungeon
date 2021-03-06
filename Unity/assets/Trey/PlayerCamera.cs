﻿using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour
{
    public GameObject FirstPersonCameraDock;
    public GameObject TopDownCameraDock;
    public PlayerCharacter Player;
    public float CameraTransitionSpeed = 5f;

    private GameObject FromCameraObject;
    private GameObject TargetCameraObject;
    private MouseLook CameraMouseLook;

    // Use this for initialization
    void Start()
    {
        TargetCameraObject = FirstPersonCameraDock;
        FromCameraObject = TopDownCameraDock;

        CameraMouseLook = GetComponent<MouseLook>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.ViewOption == PlayerViewOptions.TopDown)
        {
            TargetCameraObject = TopDownCameraDock;
            CameraMouseLook.enabled = false;
            FromCameraObject = FirstPersonCameraDock;
        }
        else
        {
            TargetCameraObject = FirstPersonCameraDock;
            FromCameraObject = TopDownCameraDock;
        }

        if (this.transform.position != TargetCameraObject.transform.position)
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, TargetCameraObject.transform.rotation, Time.deltaTime * CameraTransitionSpeed);
            this.transform.position = Vector3.Slerp(this.transform.position, TargetCameraObject.transform.position, Time.deltaTime * CameraTransitionSpeed);

            if (Vector3.Distance(this.transform.position, TargetCameraObject.transform.position) < .5f && TargetCameraObject == FirstPersonCameraDock)
            { // Destination Reached
                CameraMouseLook.enabled = true;
            }
        }
    }
}
