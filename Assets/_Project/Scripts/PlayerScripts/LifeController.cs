using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LifeController : MonoBehaviour
{
    [SerializeField] private int _maxHp = 100;
    [SerializeField] private int _hp;
    [SerializeField] private UnityEvent<int, int> _onHealtChanged;
    [SerializeField] private UnityEvent _onDeath;

    private void Start()
    {
        _hp = _maxHp;
        _onHealtChanged.Invoke(_hp, _maxHp);
    }
    public void TakeDamage(int damage)
    {
        _hp -= damage;
        if( _hp <= 0 )
        {
            Destroy(gameObject);
            _onDeath.Invoke();
        }
        _onHealtChanged.Invoke(_hp, _maxHp);
    }
}
