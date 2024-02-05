using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Transform _ball;
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _AI;

    [SerializeField] private ScoreTrigger _playerGoal;
    [SerializeField] private ScoreTrigger _AIGoal;

    private Vector3[] _startPositions = new Vector3[3];
    private Rigidbody2D _ballRB;

    private void Start()
    {
        _startPositions[0] = _ball.position;
        _startPositions[1] = _player.position;
        _startPositions[2] = _AI.position;

        _ballRB = _ball.GetComponent<Rigidbody2D>();
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

    private void OnEnable()
    {
        _playerGoal._score += ResetGame;
        _AIGoal._score += ResetGame;
    }

    private void OnDisable()
    {
        _playerGoal._score -= ResetGame;
        _AIGoal._score -= ResetGame;
    }
}
