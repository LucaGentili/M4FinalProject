using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RotationTurret : MonoBehaviour
{
    [SerializeField] private DetectionRange _range;
    [SerializeField] private float _speed;

    private void RotationOnTarget()
    {
        if (_range.Target != null)
        {
            Vector3 direction = _range.Target.position - transform.position;
            direction.y = 0;

            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _speed * Time.deltaTime);
        }
    }
    private void Update()
    {
        RotationOnTarget();
    }
}
