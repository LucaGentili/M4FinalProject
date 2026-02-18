using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinDoor : MonoBehaviour
{
    [SerializeField] private CoinManager _coinManager;
    [SerializeField] private int _requiredCoins;

    private void Update()
    {
        OpenDoor();
    }

    private void OpenDoor()
    {
        if (_coinManager.HasReachedCoins(_requiredCoins))
        {
            Destroy(gameObject);
        }
    }
}
