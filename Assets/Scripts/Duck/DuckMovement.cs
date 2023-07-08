using UnityEngine;

public class DuckMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float _swingForce;
    [SerializeField] private float _maxVerticalVelocity;
    
    private int _direction;

    public void Initialize(InputService inputService)
    {
        inputService.Swing += Swing;
        inputService.FlyDirectionChanged += ChangeDirection;
        _direction = 1;
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
        Debug.Log($"Direction was changed {direction}");
    }
    
    private void Swing()
    {
        _rigidbody.AddForce(Vector2.up * _swingForce, ForceMode2D.Impulse);
        float verticalVelocity = Mathf.Clamp(_rigidbody.velocity.y, -_maxVerticalVelocity, _maxVerticalVelocity);
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, verticalVelocity);
    }
}
