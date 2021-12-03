using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player_Health : MonoBehaviour
{
    [Header ("Health Parameters")]
    [SerializeField] private int _maxHealth = 20;
    private int _health;

    [Header("UI")]
    [SerializeField] private Slider _healthBarSlider;
    [SerializeField] private TextMeshProUGUI _healthText;

    private SceneTransition _sceneTransition;


    private void Start()
    {
        _sceneTransition = FindObjectOfType<SceneTransition>();

        _health = _maxHealth;

        _healthBarSlider.maxValue = _maxHealth;

        UpdateHealthUI();
    }


    public void TakeDamage(int damage)
    {
        _health -= damage;

        UpdateHealthUI();

        if (_health <= 0)
        {
            _health = 0;

            _sceneTransition.GoingToNextScene();
        }

    }


    private void UpdateHealthUI()
    {
        _healthText.text = $"{_health}/{_maxHealth}";

        _healthBarSlider.value = _health;
    }
}