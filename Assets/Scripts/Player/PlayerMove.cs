using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("������Ʈ")]
    private CharacterController _playerController;

    [Header("��ġ ����")]
    public bool canMove;
    [SerializeField] private float _playerSpeed;
    [SerializeField] private float _gravtiy;
    [SerializeField] private float _turnningSpeed;

    [Header("������ ���")]
    private Vector3 _moveDir;
    private float _verticalVelocity;

    private void Awake()
    {
        canMove = true;
        _playerController = GetComponent<CharacterController>();
    }
    private void PlayerGravity()
    {
        if (_playerController.isGrounded == false)
        {
            _verticalVelocity = _gravtiy * Time.fixedDeltaTime;
        }
        else
        {
            _verticalVelocity = _gravtiy * 0.3f * Time.fixedDeltaTime;
        }
    }
    public void StopImmediately()
    {
        _moveDir = Vector3.zero;
    }

    public void SetMoveValue(Vector3 value)
    {
        if (value.sqrMagnitude < 1)
        {
            StopImmediately();
        }
        _moveDir = value;
    }
    private void CalculatorMove()
    {
        _moveDir.Normalize();
        _moveDir *= _playerSpeed * Time.fixedDeltaTime;

        if (canMove)
        {
            Vector3 moveDirection = Quaternion.Euler(0, GameManager.Instance.mainCam.transform.eulerAngles.y, 0) * _moveDir;
            Vector3 move = moveDirection + _verticalVelocity * Vector3.up;
            _playerController.Move(move);
        }
    }
    
    void FixedUpdate()
    {
        PlayerGravity();
        CalculatorMove();
    }
}
