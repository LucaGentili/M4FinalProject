using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _rotationSpeed = 0.2f;
    [SerializeField] private int _maxJump;
    [SerializeField] private int _jumpForce;

    private int _jumpNumber;
    private float _h, _v;
    private Camera _mainCamera;

    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private CameraOrbit _cameraOrbit;
    private Vector3 _direction;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _mainCamera = Camera.main;  
    }
    private void Update()
    {
        _h = Input.GetAxis("Horizontal");
        _v = Input.GetAxis("Vertical");

        if(Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        //_direction = new Vector3 (_h, 0, _v);
        _direction = _mainCamera.transform.forward * _v + _mainCamera.transform.right * _h;
        _direction.y = 0;
    }
    private void FixedUpdate()
    {
        //_cameraOrbit.ConvertInputToCameraDirection(_direction);
        
        if(_direction.magnitude > 0.01f)
        {
            _direction.Normalize();
            Vector3 velocity = _direction * _speed;
            _rb.velocity = new Vector3(velocity.x, _rb.velocity.y, velocity.z);
            Quaternion targetRotation = Quaternion.LookRotation(_direction);
            Quaternion rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
            _rb.MoveRotation(rotation);
        }
        else
        {
            _rb.velocity = Vector3.zero;
            //_rb.angularVelocity = Vector3.zero;
        }
    }

    private void Jump()
    {
        if (_groundChecker.IsGrounded)
        {
            _jumpNumber = 0;
        }

        if (_jumpNumber < _maxJump)
        {
            _jumpNumber++;
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);
        }
    }
}
