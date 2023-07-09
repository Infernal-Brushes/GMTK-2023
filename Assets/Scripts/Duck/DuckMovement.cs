using System;
using System.Collections;
using Duck;
using UnityEngine;

public class DuckMovement : MonoBehaviour
{
    public event Action<int> DirectionChanged;
    public event Action OnSwing;
    
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float _swingForce;
    [SerializeField] private float _maxVerticalVelocity;
    [SerializeField] private float _swingDelay;

    private InputService _inputService;
    private DuckHealth _duckHealth;
    private Coroutine _reloadSwingCoroutine;
    private bool _isReadyToSwing;
    private int _direction;

    public void Initialize(DuckHealth duckHealth, InputService inputService)
    {
        _duckHealth = duckHealth;
        _inputService = inputService;
        _inputService.Swing += Swing;
        _inputService.FlyDirectionChanged += ChangeDirection;
        _duckHealth.Died += Dead;
        _direction = 1;
        _isReadyToSwing = true;
    }

    // Update is called once per frame
    void Update()
    {
        MoveHorizontaly();
    }

    private void MoveHorizontaly()
    {
        if (!_duckHealth.IsAlive)
            return;
        
        _rigidbody.velocity = new Vector2(_direction * _horizontalSpeed, _rigidbody.velocity.y);
    }

    public void ChangeDirection(float direction)
    {
        if (!_duckHealth.IsAlive)
            return;
        
        _direction = direction > 0 ? 1 : -1;
        DirectionChanged?.Invoke(_direction);
    }
    
    private void Swing()
    {
        if (!_isReadyToSwing || !_duckHealth.IsAlive)
            return;
        
        _isReadyToSwing = false;
        MakeSwing();
        _reloadSwingCoroutine = StartCoroutine(ReloadSwing());
    }

    private void MakeSwing()
    {
        _rigidbody.AddForce(Vector2.up * _swingForce, ForceMode2D.Impulse);
        float verticalVelocity = Mathf.Clamp(_rigidbody.velocity.y, -_maxVerticalVelocity, _maxVerticalVelocity);
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, verticalVelocity);
        OnSwing?.Invoke();
    }

    public void ForceSwing()
    {
        MakeSwing();
    }

    public IEnumerator ReloadSwing()
    {
        yield return new WaitForSeconds(_swingDelay);
        _isReadyToSwing = true;
    }

    public void Dead()
    {
        _rigidbody.isKinematic = true;
        _rigidbody.gravityScale = 0;
        _rigidbody.velocity = Vector2.zero;
        _collider.enabled = false;
        StartCoroutine(WaitToFall());
    }

    public IEnumerator WaitToFall()
    {
        yield return new WaitForSeconds(1f);
        _rigidbody.gravityScale = 3;
        _rigidbody.isKinematic = false;
    }
    
    private void OnDestroy()
    {
        _inputService.Swing -= Swing;
        _inputService.FlyDirectionChanged -= ChangeDirection;
        _duckHealth.Died -= Dead;
    }
}
