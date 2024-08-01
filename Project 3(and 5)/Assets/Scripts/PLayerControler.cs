using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerControler : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _turnSpeed;


    private void Update()
    {
        Move();
        Turn();
        ApplyGravity();
    }

    private void ApplyGravity()
    {
        _characterController.Move(Vector3.down * 10 * Time.deltaTime);
    }
    private void Turn()
    {
        float turnAngle = Input.GetAxis("Mouse X");

        transform.Rotate(Vector3.up, turnAngle * _turnSpeed * Time.deltaTime);
    }
    
    private void Move()
    {
        Vector3 moveVector = GetMoveVector();
        moveVector = transform.rotation * moveVector;

        _characterController.Move(moveVector * _speed * Time.deltaTime);
        
        bool isRunning = moveVector.magnitude > 0;
        _animator.SetBool("isRunning", isRunning);
        
    }

    private Vector3 GetMoveVector()
    {
        return new Vector3(
            Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical")
        ).normalized;

    }
}