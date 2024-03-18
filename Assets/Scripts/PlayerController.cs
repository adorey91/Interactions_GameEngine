using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 5f;
    private float moveSpeed;
    private Rigidbody2D _rb;
    private Vector2 _movement;
    [SerializeField] private Animator _animator;
    [SerializeField] private bool isRunning;
    [SerializeField] private bool isRolling;

    public void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
    }

    public void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
            isRolling = true;
    }

    public void FixedUpdate()
    {
        HandleMove();
        HandleAnimation();
    }

    private void HandleMove()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = walkSpeed * 2;
            isRunning = true;
        }
        else
        {
            moveSpeed = walkSpeed;
            isRunning = false;
        }
        _rb.MovePosition(_rb.position + _movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    private void HandleAnimation()
    {

        if (_movement != Vector2.zero)
        {
            _animator.SetFloat("MoveInputX", _movement.x);
            _animator.SetFloat("MoveInputY", _movement.y);
            _animator.SetBool("Moving", true);
     
            if(isRolling)
            {
                _animator.SetTrigger("Rolling");
                isRolling = false;
            }
            if (isRunning)
                _animator.speed = 2;
            else
                _animator.speed = 1;
        }
        else
            _animator.SetBool("Moving", false);
    }
}
