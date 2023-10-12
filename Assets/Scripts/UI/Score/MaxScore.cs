using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MaxScore : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private TMP_Text _maxScore;

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
            if (maxScore == 0 || maxScore == score)
            {
                _maxScore.text = string.Empty;
            }
            else
            {
                _maxScore.text = maxScore.ToString();               
            }
        }
        else
        {            
            _maxScore.text = string.Empty;
        }
    }
}
