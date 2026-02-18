using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _lifespan;

    private Rigidbody _rb;
    private void Start()
    {
        Destroy(gameObject, _lifespan);
    }
    public void SetUp(Vector3 direction)
    {
        if (_rb == null) _rb = GetComponent<Rigidbody>();
        _rb.velocity = direction * _speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.TryGetComponent<LifeController>(out var lifeController)) return;
        lifeController.TakeDamage(_damage);
    }
}
