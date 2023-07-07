using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float _gravity;
    [SerializeField] private float _swingForce;
    
    private Vector2 _direction;
    
    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        _direction = Vector2.right;
        Physics.gravity = new Vector3(0, _gravity, 0);
    }

    private void Update()
    {
        MoveHorizontaly();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Swing();
    }

    private void MoveHorizontaly()
    {
        if (Input.GetAxis("Horizontal") != 0)
            _direction = new Vector2(Input.GetAxis("Horizontal"), 0);
        
        _rigidbody.MovePosition(_direction * _horizontalSpeed);
    }

    private void Swing()
    {
        _rigidbody.AddForce(Vector2.up * _swingForce, ForceMode2D.Impulse);
    }
}
