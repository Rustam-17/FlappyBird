using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]

public class Bird : MonoBehaviour
{
    [SerializeField] private BirdMover _mover;

    private AudioSource _audioSource;
    private int _score;
    private int _maxScore;
    
    public event UnityAction<int, int> ScoreChanged;
    public event UnityAction GameOver;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _mover = GetComponent<BirdMover>();
        _score = 0;
        _maxScore = 0;
    }

    public void IncreaseScore()
    {
        _score++;

        if (_maxScore < _score)
        {
            _maxScore = _score;
        }

        ScoreChanged?.Invoke(_score, _maxScore);
    }

    public void ResetPlayer()
    {
        _mover.ResetBird();
        _score = 0;

        ScoreChanged?.Invoke(_score, _maxScore);
    }

    public void Die()
    {
        _audioSource.Play();

        GameOver?.Invoke();
    }
}
