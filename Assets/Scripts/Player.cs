using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _currentHP;
    [SerializeField] private int _maxHP;

    public event UnityAction<int> HealthChanged;

    public int MaxHP => _maxHP;
    public int CurrentHP => _currentHP;

    private void Awake()
    {
        _currentHP = _maxHP / 2;
    }

    public void IncreaseCurrentHealth(int value)
    {
        _currentHP += value;
        HealthChanged?.Invoke(_currentHP);
    }

    public void DeacreseCurrentHealth(int value)
    {
        _currentHP -= value;
        HealthChanged?.Invoke(_currentHP);
    }
}