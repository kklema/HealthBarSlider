using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [Header("Set in inspector")]
    [SerializeField] private Player _player;
    [SerializeField] private HealthChanger _healthChanger;
    [SerializeField] private TMP_Text _text;

    [SerializeField] private float _changeSpeed;

    private Slider _sliderHP;

    private void Awake()
    {
        _sliderHP = GetComponent<Slider>();
    }

    private void Start()
    {
        _sliderHP.maxValue = _player.MaxHP;
        _sliderHP.value = _player.CurrentHP;
        InitText();
    }

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int value)
    {
        StartCoroutine(FillingBar());
        InitText();
    }

    private void InitText()
    {
        _text.text = _player.CurrentHP.ToString() + "/" + _player.MaxHP.ToString();
    }

    private IEnumerator FillingBar()
    {
        float counter = 0;
        
        while (counter < _changeSpeed)
        {
            _sliderHP.value = Mathf.MoveTowards(_sliderHP.value, _player.CurrentHP, _changeSpeed);
            counter += Time.deltaTime;

            yield return null;
        }

        _sliderHP.value = _player.CurrentHP;
    }
}