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
        // マウスカーソルをロック
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        Move();
        RotateView();
    }
    void Move()
    {
        // 接地判定
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // 接地時に速度をリセット
        }
        // 移動入力
        float horizontal = Input.GetAxis("Horizontal"); // A/Dキー
        float vertical = Input.GetAxis("Vertical");     // W/Sキー
        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        // スプリント判定
        float speed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;
        // キャラクターの移動
        controller.Move(move * speed * Time.deltaTime);
        // ジャンプ
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }
        // 重力
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    void RotateView()
    {
        // マウス入力
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        // カメラの上下回転
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // 上下回転を制限
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        // キャラクターの左右回転
        transform.Rotate(Vector3.up * mouseX);
    }
}