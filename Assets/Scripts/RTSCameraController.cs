﻿using System;
using UnityEngine;

namespace ComputerGraphics
{
    public class RTSCameraController : MonoBehaviour
    {
        [SerializeField] float panBorderSize = 20f;
        [SerializeField] float panSpeed = 10f;
        [SerializeField] float turnSpeed = 100f;
        [SerializeField] float zoomSpeed = 0.5f;

        Camera cam;
        Vector3 rigPos;
        Vector3 camInitLocalOffset;
        float zoomFactor = 1f;

        void Start()
        {
            cam = GetComponentInChildren<Camera>();
            camInitLocalOffset = cam.transform.localPosition;
            cam.transform.LookAt(transform.position, Vector3.up);   //Look at center of rig
        }

        void Update()
        {
            MoveAndRotate();
            Zoom();
        }

        void Zoom()
        {
            var camLocalPos = cam.transform.localPosition;
            zoomFactor -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            camLocalPos.y = camInitLocalOffset.y * zoomFactor;
            camLocalPos.z = camInitLocalOffset.z * zoomFactor;
            cam.transform.localPosition = camLocalPos;
        }

        private void MoveAndRotate()
        {
            rigPos = transform.position;

            var mx = Input.mousePosition.x;
            var my = Input.mousePosition.y;

            //Pan Up
            if (my >= Screen.height - panBorderSize || Input.GetKey(KeyCode.W))
            {
                rigPos += transform.forward * panSpeed * Time.deltaTime;
            }
            //Pan Down
            if (my <= panBorderSize || Input.GetKey(KeyCode.S))
            {
                rigPos -= transform.forward * panSpeed * Time.deltaTime;
            }
            //Pan Left
            if (mx <= panBorderSize || Input.GetKey(KeyCode.A))
            {
                rigPos -= transform.right * panSpeed * Time.deltaTime;
            }
            //Pan Right
            if (mx >= Screen.width - panBorderSize || Input.GetKey(KeyCode.D))
            {
                rigPos += transform.right * panSpeed * Time.deltaTime;
            }

            //Rotate about
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse1))
            {
                var mxInput = Input.GetAxis("Mouse X");
                // var myInput = Input.GetAxis("Mouse Y");

                //Rotate about Y
                transform.Rotate(Vector3.up, Time.deltaTime * mxInput * turnSpeed);
            }

            //Clamp and set position
            transform.position = rigPos;
        }
    }
}