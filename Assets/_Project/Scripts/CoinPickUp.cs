using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : PickUp
{
    [SerializeField] private int _addCoins;

    private CoinManager _coins;

    public override void OnPick(GameObject picker)
    {
        _coins.AddCoins(_addCoins);
    }

    private void Awake()
    {
        _coins = FindObjectOfType<CoinManager>();
    }
}
