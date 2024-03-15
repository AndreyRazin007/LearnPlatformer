using UnityEngine;

public class PlayerMovevement : MonoBehaviour {
    private float _input;
    private float _speed = 3f;
    private float _jumpSpeed = 3.5f;
    private bool _isGrounded;
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    internal bool rightOrientation = true;

    [SerializeField] private float _rad = 0.1f;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private Transform _feets;

    private void Start() {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();        
    }

    private void Update() {
        _input = Input.GetAxis("Horizontal");
        _rigidbody.velocity = new Vector2(_input * _speed, _rigidbody.velocity.y);

        _isGrounded = Physics2D.OverlapCircle(_feets.position, _rad, _ground);

        if(_isGrounded && Input.GetKeyDown(KeyCode.Space)) {
            _rigidbody.velocity = Vector2.up * _jumpSpeed;
            _animator.SetTrigger("jump");
        }

        if (_isGrounded) {
            _animator.SetBool("isGrounded", true);
        } else {
            _animator.SetBool("isGrounded", false);
        }

        if (_input != 0) {
            _animator.SetBool("isRunning", true);
        } else {
            _animator.SetBool("isRunning", false);
        }

        if(rightOrientation && _input < 0) {
            Flip();
        } else if (!rightOrientation && _input > 0) {
            Flip();
        }
    }

    public void Flip() {
        rightOrientation = !rightOrientation;

        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
