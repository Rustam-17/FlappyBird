using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BirdMover))]

public class BirdStartBehaviour : MonoBehaviour
{
    [SerializeField] private float _tossPositionY;
    [SerializeField] private float _spread;
    [SerializeField] private float _fallingAngle;

    private BirdMover _birdMover;
    private float _singleTossPositionY;

    private void Start()
    {
        _birdMover = GetComponent<BirdMover>();
        _singleTossPositionY = _tossPositionY;
    }

    private void Update()
    {
        if (IsFalling() && transform.position.y < _singleTossPositionY)
        {
            _birdMover.TossBird();
            _singleTossPositionY = Random.Range(_tossPositionY - _spread, _tossPositionY + _spread);
        }
    }

    private bool IsFalling()
    {
        return transform.rotation.z < _fallingAngle;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(new Vector3(-5, _singleTossPositionY), new Vector3(-4, _singleTossPositionY));

        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(-7, _tossPositionY + _spread), new Vector3(-5, _tossPositionY + _spread));
        Gizmos.DrawLine(new Vector3(-6.5f, _tossPositionY), new Vector3(-5.5f, _tossPositionY));
        Gizmos.DrawLine(new Vector3(-7, _tossPositionY - _spread), new Vector3(-5, _tossPositionY - _spread));
    }
}
