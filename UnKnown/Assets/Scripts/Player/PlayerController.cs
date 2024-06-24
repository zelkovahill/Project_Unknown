using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;     // 이동 속도
    public float rotateSpeed;   // 회전 속도
    public float jumpForce;     // 점프
    public float mouseSensitivity; // 마우스 감도
    
    public bool isGrounded;     // 땅에 닿았는지 확인

    public StateMachine stateMachine;
    private float rotationY = 0f;

    private Rigidbody _rb;
    

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        
        stateMachine = new StateMachine();
        stateMachine.Initialize(new IdleState(this));
    }

    private void Update()
    {
        stateMachine.Update();
        
    }

    private void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        float rotate = Input.GetAxis("Horizontal")*rotateSpeed*Time.deltaTime;
        transform.Rotate(mouseX * Vector3.up);

        rotationY -= mouseY;
        rotationY = Mathf.Clamp(rotationY, -90f, 90f); 
        Camera.main.transform.localRotation = Quaternion.Euler(rotationY, 0f, 0f);
    }

    private void OnCollisionStay(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public void Jump()
    {
        if (isGrounded)
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    public void Move(float moveInput, float strafeInput)
    {
        Vector3 moveDirection = transform.forward * moveInput + transform.right * strafeInput;
        moveDirection *= moveSpeed * Time.deltaTime;
        _rb.MovePosition(transform.position + moveDirection);

        
    }
}
