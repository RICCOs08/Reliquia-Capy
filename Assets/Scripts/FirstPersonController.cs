using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    [SerializeField] private float _walkSpeed = 4f;
    [SerializeField] private float _runSpeed = 10f;
    [SerializeField] private float _mouseSense = 400f;
    [SerializeField] private float _jumpHeight = 1f;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundCheker;

    private float _speed;
    private CharacterController _characterController;
    private Vector2 _moveDir;
    private Vector2 _mouseDir;
    private Vector3 _move;

    private bool _isJump;
    private bool _isGrounded;
    private bool _isRun;

    private const float G = 9.8f;
    private float _rotationCamY;
    private Transform _cameraTransform;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _cameraTransform = Camera.main.transform;
    }

    
    void Update()
    {
        PlayerInput();
        SetGravity();
        OnJump();
        OnRotate();
        OnMove();
    }

    private void PlayerInput()
    {
        _moveDir.x = Input.GetAxisRaw("Horizontal");
        _moveDir.y = Input.GetAxisRaw("Vertical");
        _moveDir.Normalize();

        _mouseDir.x = Input.GetAxis("Mouse X");
        _mouseDir.y = Input.GetAxis("Mouse Y");

        _isJump = Input.GetKeyDown(KeyCode.Space);
        _isRun = Input.GetKey(KeyCode.LeftShift);
    }

    private void SetGravity()
    {
        _isGrounded = Physics.CheckSphere(_groundCheker.position, 0.5f, _groundLayer);

        _move.y -= G * Time.deltaTime;

        if(_isGrounded)
        {
            _move.y = -2;
        }
    }

    private void OnJump()
    {
        if(_isJump == true && _isGrounded == true)
        {
            _move.y = Mathf.Sqrt(2 * G * _jumpHeight);
        }
    }

    private void OnRotate()
    {
        _mouseDir *= Time.deltaTime * _mouseSense;

        transform.Rotate(Vector3.up * _mouseDir.x);

        _rotationCamY -= _mouseDir.y;
        _rotationCamY = Mathf.Clamp(_rotationCamY, -45f, 35f);
        _cameraTransform.localEulerAngles = Vector3.right * _rotationCamY;
    }

    private void OnMove()
    {

        if(_isRun == true)
        {
            _speed = _runSpeed;
        }
        else
        {
            _speed = _walkSpeed;
        }

        _moveDir *= _speed;
        _move.x = _moveDir.x;
        _move.z = _moveDir.y;

        _move = transform.TransformDirection(_move);

        _characterController.Move(_move * Time.deltaTime);
    }
}
