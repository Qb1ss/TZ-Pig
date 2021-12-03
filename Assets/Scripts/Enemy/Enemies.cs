using UnityEngine;
using System.Collections;

public class Enemies : MonoBehaviour
{
    [Header("Moving Parameters")]
    [SerializeField] private float _movingSpeed;
    private float _currentMovingSpeed;
    [Space (height: 5f)]

    [SerializeField] private float _waitTime;
    private float _btwWaitTime;
    [Space(height: 5f)]

    private int _currentPoint;
    [Space(height: 5f)]

    [SerializeField] private Transform[] _patrolPoints;

    [Header("Attack Parameters")]
    [SerializeField] private float _attackCooldown = 2;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private Transform _transform;

    protected HashAnimationsNames _hashAnimationsNames = new HashAnimationsNames();


    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _transform = GetComponent<Transform>();

        _currentMovingSpeed = _movingSpeed;
    }


    private void FixedUpdate()
    {
        PlayerMoving();
    }


    private void PlayerMoving()
    {
        PatrollingTerritory();
    }


    public void Attack()
    {
        StartCoroutine(AttackCoroutine());
    }


    public void Die()
    {
        
    }


    private IEnumerator AttackCoroutine()
    {
        _currentMovingSpeed = 0;

        yield return new WaitForSeconds(_attackCooldown);

        _currentMovingSpeed = _movingSpeed;

        yield break;
    }

    #region Moving
    private void PatrollingTerritory()
    {
        _transform.position = Vector2.MoveTowards(_transform.position, _patrolPoints[_currentPoint].position, _currentMovingSpeed * Time.fixedDeltaTime);
        
        CheckedDirection();

        if (Vector2.Distance(_transform.position, _patrolPoints[_currentPoint].position) < 0.1f)
        {
            if (_btwWaitTime >= _waitTime)
            {
                _btwWaitTime = 0;

                _currentPoint++;
                
                if (_currentPoint >= _patrolPoints.Length)
                {
                    _currentPoint = 0;

                    return;
                }
            }
            else
            {
                _btwWaitTime += Time.deltaTime;
            }
        }
    }


    private void CheckedDirection()
    {
        float gameObjectPositionX = Mathf.CeilToInt(_transform.position.x);
        float gameObjectPositionY = Mathf.CeilToInt(_transform.position.y);

        float patrolPointPositionX = Mathf.CeilToInt(_patrolPoints[_currentPoint].position.x);
        float patrolPointPositionY = Mathf.CeilToInt(_patrolPoints[_currentPoint].position.y);

        if (gameObjectPositionX > patrolPointPositionX)
        {
            MovingRight();
        }
        else if (gameObjectPositionX < patrolPointPositionX)
        {
            MovingLeft();
        }

        if (gameObjectPositionY > patrolPointPositionY)
        {
            MovingDown();
        }
        else if (gameObjectPositionY < patrolPointPositionY)
        {
            MovingUp();
        }
    }
    #endregion

    #region Animations
    private void MovingUp()
    {
        _animator.SetTrigger(_hashAnimationsNames.UpDirection);
    }


    private void MovingDown()
    {
        _animator.SetTrigger(_hashAnimationsNames.DownDirection);
    }


    private void MovingLeft()
    {
        _animator.SetTrigger(_hashAnimationsNames.LeftDirection);
    }


    private void MovingRight()
    {
        _animator.SetTrigger(_hashAnimationsNames.RightDirection);
    }
    #endregion
}