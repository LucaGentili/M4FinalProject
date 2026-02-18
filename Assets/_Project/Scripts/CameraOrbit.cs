using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    [SerializeField] private float _mouseSensitivity, _bottomClamp, _topClamp; 
    private float yaw;
    private float pitch;

    public Transform target;
    public Vector3 offset;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * _mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") + _mouseSensitivity;
        pitch = Mathf.Clamp(pitch, _bottomClamp, _topClamp);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 desideredPosition = target.position + rotation * offset;

        Vector3 lookAt = target.position + Vector3.up * 2;
        Quaternion lookRotation = Quaternion.LookRotation(lookAt - desideredPosition);
        transform.SetPositionAndRotation(desideredPosition, lookRotation);
    }

    public Vector3 ConvertInputToCameraDirection(Vector3 input)
    {
        Vector3 cameraForward = transform.forward;
        Vector3 cameraRight = transform.right;

        Vector3 moveDir = cameraForward * input.z + cameraRight * input.x;
        moveDir.y = 0;

        if (moveDir.magnitude > 0.02f) moveDir.Normalize();

        return moveDir;
    }
}
