using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.Events;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private float _maxDistance = 0.1f;
    [SerializeField] private LayerMask _whatIsGround;

    [SerializeField] private UnityEvent<bool> _onIsGroundedChanged;

    public bool IsGrounded { get; private set; }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _maxDistance);
    }
    void Update()
    {
        bool wasGrounded = IsGrounded;
        IsGrounded = Physics.CheckSphere(transform.position, _maxDistance, _whatIsGround);

        if (wasGrounded != IsGrounded)
        {
            _onIsGroundedChanged?.Invoke(IsGrounded);
        }
    }
}
