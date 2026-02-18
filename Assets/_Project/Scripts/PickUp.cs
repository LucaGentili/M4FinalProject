using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUp : MonoBehaviour
{
    [SerializeField] private float _altitude = 0.1f;
    [SerializeField] private float _altitudeSpeed = 2f;
    [SerializeField] private float _rotationSpeed = 5f;

    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    public abstract void OnPick(GameObject picker);

    private void Update()
    {
        float offSetY = Mathf.Sin(Time.time * _altitudeSpeed) * _altitude;
        transform.position = _startPosition + Vector3.up * offSetY;
        transform.Rotate(Vector3.up * _rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        OnPick(other.gameObject);

        Destroy(gameObject);
    }

}
