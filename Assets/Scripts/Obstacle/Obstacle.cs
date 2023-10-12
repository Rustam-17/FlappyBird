using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private GameObject _pipe1;
    [SerializeField] private GameObject _pipe2;
    [SerializeField] private GameObject _scoreZone;
    [SerializeField] private float _scoreZoneSize;
    [SerializeField] private float _pozitionZ;

    private Vector3 _pipe1Position;
    private Vector3 _pipe2Position;
    private Vector3 _scoreZonePosition;

    private void Start()
    {
        _pipe1Position = new Vector3(0, -CalculatePipePositionY(_pipe1), _pozitionZ);
        _pipe2Position = new Vector3(0, CalculatePipePositionY(_pipe2), _pozitionZ);
        _scoreZonePosition = new Vector2(CalculateScoreZonePositionX(_pipe1), 0);

        _pipe1.transform.localPosition = _pipe1Position;
        _pipe2.transform.localPosition = _pipe2Position;

        _scoreZone.GetComponent<BoxCollider2D>().offset = _scoreZonePosition;
        _scoreZone.GetComponent<BoxCollider2D>().size = new Vector2(0.2f, _scoreZoneSize);
    }

    private float CalculatePipePositionY(GameObject pipe)
    {
        float halfDivider = 2;
        float _pipeLenght = pipe.GetComponent<SpriteRenderer>().bounds.size.y;

        return (_pipeLenght + _scoreZoneSize) / halfDivider;
    }

    private float CalculateScoreZonePositionX(GameObject pipe)
    {
        float halfDivider = 2;
        float _pipeWidth = pipe.GetComponent<SpriteRenderer>().bounds.size.x;

        return _pipeWidth / halfDivider;
    }
}
