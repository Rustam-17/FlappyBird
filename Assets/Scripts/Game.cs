using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private ObstacleGenegator _obstacleGenegator;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;

    public event UnityAction EscapeKeyDown;

    private void OnEnable()
    {
        _startScreen.StartKeyDown += OnStartKeyDown;
        _gameOverScreen.RestartKeyDown += OnRestartKeyDown;
        _bird.GameOver += OnGameOver;
        EscapeKeyDown += OnEscapeKeyDown;
    }

    private void OnDisable()
    {
        _startScreen.StartKeyDown -= OnStartKeyDown;
        _gameOverScreen.RestartKeyDown -= OnRestartKeyDown;
        _bird.GameOver -= OnGameOver;
        EscapeKeyDown -= OnEscapeKeyDown;
    }

    private void Start()
    {
        Time.timeScale = 1;
                
        _gameOverScreen.Close();
        _startScreen.Open();

        _bird.GetComponent<BirdStartBehaviour>().enabled = true;
        _bird.GetComponent<BirdMover>().Deactivate();

        _obstacleGenegator.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EscapeKeyDown?.Invoke();
        }
    }
        
    private void OnStartKeyDown()
    {
        Time.timeScale = 1;

        _startScreen.Close();

        _obstacleGenegator.enabled = true;

        _bird.GetComponent<BirdStartBehaviour>().enabled = false;
        _bird.GetComponent<BirdMover>().Activate();
    }

    private void OnRestartKeyDown()
    {
        Time.timeScale = 1;

        _gameOverScreen.Close();

        _obstacleGenegator.ResetPool();

        _bird.GetComponent<BirdStartBehaviour>().enabled = false;
        _bird.GetComponent<BirdMover>().Activate();
        _bird.ResetPlayer();
    }

    private void OnEscapeKeyDown()
    {
        Time.timeScale = 1;

        _gameOverScreen.Close();
        _startScreen.Open();

        _obstacleGenegator.ResetPool();
        _obstacleGenegator.enabled = false;

        _bird.GetComponent<BirdStartBehaviour>().enabled = true;
        _bird.GetComponent<BirdMover>().Deactivate();
        _bird.ResetPlayer();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;

        _gameOverScreen.Open();

        _bird.GetComponent<BirdMover>().Deactivate();
    }
}