using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class BirdMover : MonoBehaviour
{
    [SerializeField] private Vector2 _startPosition;
    [SerializeField] private float _tossForce;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _maxRotationZ;

    private Rigidbody2D _rigidbody;
    private Quaternion _minRotation;
    private Quaternion _maxRotation;
    private bool _isEnabled;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);

        Deactivate();
        ResetBird();
    }

    private void Update()
    {
        if (_isEnabled)
        {
            if (Input.touchCount == 1)
            {
                TossBird();
            }
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public void TossBird()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _maxRotation, _rotationSpeed * 1000 * Time.deltaTime);

        _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.x);
        _rigidbody.AddForce(Vector2.up * _tossForce, ForceMode2D.Impulse);
    }

    public void ResetBird()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        _rigidbody.velocity = Vector2.zero;
    }

    public void Activate()
    {
        _isEnabled = true;
    }

    public void Deactivate()
    {
        _isEnabled = false;
    }
}
