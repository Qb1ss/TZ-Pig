using UnityEngine;
using UnityEngine.UI;

public class Player_Movement : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float _movingSpeed;

    private Vector2 _direction;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    protected HashAnimationsNames _hashAnimationsNames = new HashAnimationsNames();


    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }


    private void FixedUpdate()
    {
        PlayerMoving();
    }


    private void PlayerMoving()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _direction * _movingSpeed * Time.fixedDeltaTime);
    }

    #region MovingButtons
    public void MovingUpButton()
    {
        _animator.SetTrigger(_hashAnimationsNames.UpDirection);

        _direction.x = 0;
        _direction.y = 1;
    }


    public void MovingDownButton()
    {
        _animator.SetTrigger(_hashAnimationsNames.DownDirection);

        _direction.x = 0;
        _direction.y = -1;
    }


    public void MovingLeftButton()
    {
        _animator.SetTrigger(_hashAnimationsNames.LeftDirection);

        _direction.x = 1;
        _direction.y = 0;
    }


    public void MovingRightButton()
    {
        _animator.SetTrigger(_hashAnimationsNames.RightDirection);

        _direction.x = -1;
        _direction.y = 0;
    }


    public void MovingButtonsUpButton()
    {
        _direction.x = 0;
        _direction.y = 0;
    }
    #endregion
}