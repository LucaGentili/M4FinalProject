using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTurret : MonoBehaviour
{
    [SerializeField] private float _fireRange = 0;
    [SerializeField] private float _fireRate = 0;
    [SerializeField] private DetectionRange _range;
    [SerializeField] public Bullet bulletPrefab;
    [SerializeField] private float _radius;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private LayerMask _layerMask;

    private float _lastShoot = 0f;

    private void ShootOnTarget()
    {
        if (_range.Target != null)
        {
            if (IfShoot())
            {
                SphereCastShoot();
                _lastShoot = Time.time;
            }
        }
    }
    private bool IfShoot()
    {
        return Time.time - _lastShoot >= _fireRate;
    }
    private void SphereCastShoot()
    {
        Vector3 direction = (_range.Target.position - _shootPoint.position).normalized;
        
        Debug.DrawRay(_shootPoint.position, direction * _fireRange, Color.black, _fireRate);
        
        if (Physics.SphereCast(_shootPoint.position, _radius, direction, out RaycastHit hitinfo, _fireRange, _layerMask))
        {
            InstantiateBullet(direction);
        }
    }
    private void InstantiateBullet(Vector3 shootDir)
    {
        Bullet clone = Instantiate(bulletPrefab, _shootPoint.position, _shootPoint.rotation, _shootPoint);
        clone.SetUp(shootDir);
    }
    private void Update()
    {
        ShootOnTarget();
    }
}
