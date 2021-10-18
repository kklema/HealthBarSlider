using UnityEngine;

public class HealthChanger : MonoBehaviour
{
    [SerializeField] private int _increaseValue;
    [SerializeField] private int _deacreseValue;

    [Header("Set in inspector")]
    [SerializeField] private Player _player;

    public void IncreaseHealth()
    {
        _player.IncreaseCurrentHealth(_increaseValue);
    }

    public void DecreaseHealth()
    {
        _player.DeacreseCurrentHealth(_deacreseValue);
    }
}