using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float _jumpPower = 15f;
    private float _forwardPower = 9f;
    private float _gravityModyfier = 15f;
    private bool _isUpBtnPush;
    private bool _isRightBtnPush;
    private bool _isLeftBtnPush;
    private bool _isGrounded;

    [SerializeField] private Text _scoreTxt;
    private int _score;

    private Rigidbody _rb;
    private GameManager _gameManager;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _gameManager = FindObjectOfType<GameManager>();
        _score = 0;
    }
    private void Start()
    {
        Physics.gravity *= _gravityModyfier;
        _isGrounded = false;
    }
    void Update()
    {
        _isUpBtnPush = Input.GetKey(KeyCode.UpArrow);
        _isRightBtnPush = Input.GetKey(KeyCode.RightArrow);
        _isLeftBtnPush = Input.GetKey(KeyCode.LeftArrow);


        _scoreTxt.text = _score.ToString();

    }
    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {

        if (_isUpBtnPush && _isGrounded && _gameManager.IsGameOver != true)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            _rb.AddForce(0, _jumpPower, _forwardPower, ForceMode.Impulse);
            _isGrounded = false;
            _score++;
        }
        else if (_isRightBtnPush && _isGrounded && _gameManager.IsGameOver != true)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            _rb.AddForce(_forwardPower, _jumpPower,0, ForceMode.Impulse);
            _isGrounded = false;
        }
        else if (_isLeftBtnPush && _isGrounded && _gameManager.IsGameOver != true)
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
            _gameManager.IsGameOver = true;
        }
    }
}
