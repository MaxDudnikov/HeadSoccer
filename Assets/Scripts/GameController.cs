using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Transform _ball;
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _AI;

    [SerializeField] private ScoreTrigger _playerGoal;
    [SerializeField] private ScoreTrigger _AIGoal;

    [SerializeField] private TextMeshProUGUI _scores;
    [SerializeField] private TextMeshProUGUI _time;

    private int _playerScore = 0;
    private int _PlayerScore
    {
        get => _playerScore;
        set
        {
            _playerScore = value;
            _scores.text = $"{_aiScore} - {_playerScore}";
        }
    }
    private int _aiScore = 0;
    private int _AIScore
    {
        get => _aiScore;
        set
        {
            _aiScore = value;
            _scores.text = $"{_aiScore} - {_playerScore}";
        }
    }

    private Vector3[] _startPositions = new Vector3[3];
    private Rigidbody2D _ballRB;

    private void Start()
    {
        _startPositions[0] = _ball.position;
        _startPositions[1] = _player.position;
        _startPositions[2] = _AI.position;

        _ballRB = _ball.GetComponent<Rigidbody2D>();

        _scores.text = $"{_AIScore} - {_PlayerScore}";
    }

    private void ResetGame()
    {
        _ballRB.velocity = Vector3.zero;
        _ballRB.angularVelocity = 0;
        _ball.position = _startPositions[0];
        _player.position = _startPositions[1];
        _AI.position = _startPositions[2];
    }

    private void StartGame()
    {

    }

    private void AddScore_AI()
    {
        _AIScore++;
    }

    private void AddScore_Player()
    {
        _PlayerScore++;
    }

    private void OnEnable()
    {
        _playerGoal._score += ResetGame;
        _AIGoal._score += ResetGame;

        _playerGoal._score += AddScore_AI;
        _AIGoal._score += AddScore_Player;
    }

    private void OnDisable()
    {
        _playerGoal._score -= ResetGame;
        _AIGoal._score -= ResetGame;

        _playerGoal._score -= AddScore_AI;
        _AIGoal._score -= AddScore_Player;
    }
}
