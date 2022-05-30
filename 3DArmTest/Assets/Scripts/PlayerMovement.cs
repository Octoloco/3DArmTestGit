using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private ArmBehaviour armBehaviour;
    [SerializeField]
    private float cameraSpeed;
    [SerializeField]
    private float movementSpeed;

    private float XRotation;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Move();
        MoveCamera();
        Pointer();
        
    }

    private void Pointer()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 100.0f))
            {
                if (hit.transform.CompareTag("controlPanel"))
                {
                    armBehaviour.ArmActiveSwitch();
                }
            }
        }
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 direction = transform.right * x + transform.forward * z;

        GetComponent<CharacterController>().Move(direction.normalized * movementSpeed * Time.deltaTime);
    }

    private void MoveCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * cameraSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * cameraSpeed * Time.deltaTime;

        XRotation -= mouseY;
        XRotation = Mathf.Clamp(XRotation, -90f, 90f);

        Camera.main.transform.localRotation = Quaternion.Euler(XRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
