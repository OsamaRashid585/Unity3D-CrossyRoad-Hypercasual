using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _jumpPower = 15f;
    private float _forwardPower = 9f;
    private float _gravityModyfier = 15f;
    private bool _isUpBtnPush;
    private bool _isRightBtnPush;
    private bool _isLeftBtnPush;
    private bool _isGrounded;

    private Rigidbody _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        Physics.gravity *= _gravityModyfier;
        _isGrounded = false;
    }
    void Update()
    {
        GetInputs();
    }
    private void FixedUpdate()
    {
        Movement();
    }

    private void GetInputs()
    {
        _isUpBtnPush = Input.GetKey(KeyCode.UpArrow);
        _isRightBtnPush = Input.GetKey(KeyCode.RightArrow);
        _isLeftBtnPush = Input.GetKey(KeyCode.LeftArrow);
    }
    private void Movement()
    {

        if (_isUpBtnPush && _isGrounded)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            _rb.AddForce(0, _jumpPower, _forwardPower, ForceMode.Impulse);
            _isGrounded = false;
        }
        else if (_isRightBtnPush && _isGrounded)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            _rb.AddForce(_forwardPower, _jumpPower,0, ForceMode.Impulse);
            _isGrounded = false;
        }
        else if (_isLeftBtnPush && _isGrounded)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            _rb.AddForce(-_forwardPower, _jumpPower, 0, ForceMode.Impulse);
            _isGrounded = false;
        }
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Vehicle")){
            transform.localScale = new Vector3(1, 1, 0.1f);
        }
    }
}
