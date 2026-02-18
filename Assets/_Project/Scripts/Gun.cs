using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float _fireRange = 0;
    [SerializeField] private float _fireRate = 0;
    [SerializeField] public Bullet bulletPrefab;
    [SerializeField] private float _radius;
    [SerializeField] private Transform _shootPoint;

    private Camera _cam;

    private float _lastShoot = 0f;

    private bool IfShoot()
    {
        return Time.time - _lastShoot >= _fireRate;
    }
    private void SphereCastShoot()
    {
        Vector3 direction = CalculateCamToMouseDirection();

        Debug.DrawRay(_shootPoint.position, direction * _fireRange, Color.black, _fireRate);

        if (Physics.SphereCast(_shootPoint.position, _radius, direction, out RaycastHit hitinfo, _fireRange))
        {
            InstantiateBullet(direction);
        }
    }

    private Vector3 CalculateCamToMouseDirection()
    {
        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = -_cam.transform.position.z;
        Vector3 mouseWorldPos = _cam.ScreenToWorldPoint(mouseScreenPos);
        Vector3 direction = (mouseWorldPos - _shootPoint.position).normalized;
        return direction;
    }

    private void InstantiateBullet(Vector3 shootDir)
    {
        Bullet clone = Instantiate(bulletPrefab, _shootPoint.position, _shootPoint.rotation, _shootPoint);
        clone.SetUp(shootDir);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            IfShoot();
            SphereCastShoot();
        }
    }
}
