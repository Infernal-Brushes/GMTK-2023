using System.Collections;
using UnityEngine;

public class DuckMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float _swingForce;
    [SerializeField] private float _maxVerticalVelocity;
    [SerializeField] private float _swingDelay;

    private Coroutine _reloadSwingCoroutine;
    private bool _isReadyToSwing;
    private int _direction;

    public void Initialize(InputService inputService)
    {
        inputService.Swing += Swing;
        inputService.FlyDirectionChanged += ChangeDirection;
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
        _rigidbody.velocity = new Vector2(_direction * _horizontalSpeed, _rigidbody.velocity.y);
    }

    public void ChangeDirection(float direction)
    {
        _direction = direction > 0 ? 1 : -1;
    }
    
    private void Swing()
    {
        if (!_isReadyToSwing)
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
}
