using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private float _zoom = 13f;
    private float _mouseSensivity = 170f;

    private float _xRotation = 0f;
    private float _yRotation = 30f;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        CalculateMovement();
        DoMovementAndRotation();
    }

    void CalculateMovement()
    {
        _xRotation += Input.GetAxis("Mouse X") * _mouseSensivity * Time.deltaTime;
        _yRotation -= Input.GetAxis("Mouse Y") * _mouseSensivity * Time.deltaTime;
    }

    void DoMovementAndRotation()
    {
        _yRotation = Mathf.Clamp(_yRotation, 0f, 80f);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(_yRotation, _xRotation, 0),
            Time.deltaTime * 30);

        Vector3 position = _target.position - transform.forward * _zoom;
        transform.position = Vector3.Slerp(transform.position, position, Time.deltaTime * 30);
    }

}