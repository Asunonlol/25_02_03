using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotatio1 : MonoBehaviour
{
    [SerializeField] Transform playerObject;

    [SerializeField] private float mouseSensitivity = 100f;

    private float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (playerObject == null)
            playerObject = GameObject.Find("Muryotaisu(1)").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 359f, -359f);
        if (playerObject != null)
        {
            playerObject.Rotate(Vector3.up * mouseX);
        }
        else
        {
            Debug.LogError("playerBodyÇ™nullÇ≈Ç∑ÅB");
        }
    }
}
