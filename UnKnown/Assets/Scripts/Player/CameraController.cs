using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   [SerializeField] private Transform player;
   [SerializeField] private Vector3 offset;
   [SerializeField] private float sensitivity = 100f;
   
   private float rotationY = 0f;
   private float rotationX = 0f;

   private void LateUpdate()
   {
      float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
      float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
      
      rotationY += mouseX;
      rotationX -= mouseY;
      rotationX = Mathf.Clamp(rotationX, -90f, 90f);
      
      transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0f);
      transform.position = player.position + offset;
   }
}
