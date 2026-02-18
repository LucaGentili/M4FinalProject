using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private UnityEvent<int> _onCoinsChanged;

    [Header("Coins")]
    [SerializeField] private int _coins;

    public int Coins => _coins;
   
    private void SetCoins(int coins)
    {
        coins = Mathf.Max(coins, 0);
        _coins = coins;
        _onCoinsChanged.Invoke(_coins);
    }

    public void AddCoins(int amount)
    {
        SetCoins(_coins + amount);
    }

    public bool HasReachedCoins(int requiredCoins) => _coins >= requiredCoins;
}
