using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float _swingForce;
    [SerializeField] private float _maxVerticalVelocity;
    
    private int _direction;
    
    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        _direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
              Swing();

        MoveHorizontaly();
    }

    private void MoveHorizontaly()
    {
        var direction = Input.GetAxis("Horizontal");
        if (direction != 0)
            _direction = direction > 0 ? 1 : -1;

        _rigidbody.velocity = new Vector2(_direction * _horizontalSpeed, _rigidbody.velocity.y);
    }

    private void Swing()
    {
        _rigidbody.AddForce(Vector2.up * _swingForce, ForceMode2D.Impulse);
        float verticalVelocity = Mathf.Clamp(_rigidbody.velocity.y, -_maxVerticalVelocity, _maxVerticalVelocity);
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, verticalVelocity);
    }
}
