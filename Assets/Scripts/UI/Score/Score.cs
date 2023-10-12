using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private TMP_Text _score;

    private void OnEnable()
    {
        _bird.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _bird.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score, int maxScore)
    {
        if (score != 0)
        {
            _score.text = score.ToString();
        }
        else
        {            
            _score.text = string.Empty;
        }
    }
}
