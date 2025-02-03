using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float walkSpeed = 5f;
    public float sprintSpeed = 10f;
    public float jumpForce = 5f;
    public float gravity = -9.81f;
    [Header("Mouse Settings")]
    public float mouseSensitivity = 100f;
    private CharacterController controller;
    private Transform cameraTransform;
    private Vector3 velocity;
    private bool isGrounded;
    private float xRotation = 0f;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
        // �}�E�X�J�[�\�������b�N
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        Move();
        RotateView();
    }
    void Move()
    {
        // �ڒn����
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // �ڒn���ɑ��x�����Z�b�g
        }
        // �ړ�����
        float horizontal = Input.GetAxis("Horizontal"); // A/D�L�[
        float vertical = Input.GetAxis("Vertical");     // W/S�L�[
        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        // �X�v�����g����
        float speed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;
        // �L�����N�^�[�̈ړ�
        controller.Move(move * speed * Time.deltaTime);
        // �W�����v
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }
        // �d��
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    void RotateView()
    {
        // �}�E�X����
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        // �J�����̏㉺��]
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // �㉺��]�𐧌�
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        // �L�����N�^�[�̍��E��]
        transform.Rotate(Vector3.up * mouseX);
    }
}