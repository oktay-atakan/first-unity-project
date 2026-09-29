using UnityEngine;
using UnityEngine.InputSystem;


public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;

    public float sensivity = 0.15f;
    float yaw;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        offset = transform.position - target.position;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(Cursor.lockState != CursorLockMode.Locked)
        {

            return;

        }

        float mouseX = Mouse.current.delta.ReadValue().x;

        yaw += mouseX * sensivity;

    }

    void LateUpdate()
    {

        Quaternion rotation = Quaternion.Euler(0f, yaw, 0f);
        Vector3 rotated_offset = rotation * offset;
        transform.position = target.position + rotated_offset;
        transform.LookAt(target);

    }
}
