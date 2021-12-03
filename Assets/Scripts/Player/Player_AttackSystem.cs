using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Player_AttackSystem : MonoBehaviour, IPointerClickHandler
{
    [Header ("Attack")]
    [SerializeField] private GameObject _bomb;
    [Space(height: 5f)]

    [SerializeField] private float _attackCooldown = 10;
    private float _btwAttackCooldown = 0;
    [Space(height: 5f)]

    [SerializeField] private int _maxBombs = 3;
    private int _bombs;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _bombsText;


    private void Start()
    {
        _bombs = _maxBombs;

        UpdateBombUI();
    }


    private void Update()
    {
        BombTimer();
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        Attack();
    }


    private void Attack()
    {
        if (_bombs > 0)
        {
            Instantiate(_bomb, transform.position, Quaternion.identity);

            _bombs--;

            UpdateBombUI();
        } 
    }


    private void BombTimer()
    {
        if (_btwAttackCooldown < _attackCooldown && _bombs != _maxBombs)
        {
            _btwAttackCooldown += Time.deltaTime;
        }
        else if (_btwAttackCooldown >= _attackCooldown && _bombs != _maxBombs)
        {
            _btwAttackCooldown = 0;
            _bombs = _maxBombs;

            UpdateBombUI();
        }
    }


    private void UpdateBombUI()
    {
        _bombsText.text = $"Pig bomb: {_bombs}/{_maxBombs}";
    }
}