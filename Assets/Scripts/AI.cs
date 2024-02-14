using Control;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField] private CharacterControl _characterControl;
    [SerializeField] private Transform _ball;
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _AI_Goal;
    [SerializeField] private Transform _Player_Goal;
    [SerializeField] private TextMeshProUGUI _TextMeshProUGUI;

    private Rigidbody2D _aiRB;
    private Animator _animator;

    private float _distanceTO_ball = 0;
    private float _distanceToKick = 1.2f;
    private float _minDistanceToBall = 2;
    private float _minOffset_X = .5f;
    private float _minOffset_Y = 1f;
    private Vector3 _ballPositionRelativeToTheAI = Vector3.zero;

    private void Start()
    {
        _aiRB = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Debug.DrawLine(transform.position, _ball.position, Color.red);
        Debug.DrawLine(transform.position, _player.position, Color.yellow);
        Debug.DrawLine(transform.position, _AI_Goal.position, Color.green);
        Debug.DrawLine(transform.position, _Player_Goal.position, Color.blue);

        //1# run back
        if (_distanceTO_ball > _minDistanceToBall && _ballPositionRelativeToTheAI.x < _minOffset_X)
        {
            _characterControl.Move_Left(transform);
        }
        //2# run forward
        if (_distanceTO_ball > _minDistanceToBall && _ballPositionRelativeToTheAI.x > _minOffset_X)
        {
            _characterControl.Move_Right(transform);
        }
        //3# get ahead ball
        else if (_distanceTO_ball > _minDistanceToBall && _ballPositionRelativeToTheAI.y > _minOffset_Y && _ballPositionRelativeToTheAI.x < _minOffset_X)
        {
            _characterControl.Move_Left(transform);
        }
        //4# try to catch ball
        else if (_distanceTO_ball < _minDistanceToBall && _ballPositionRelativeToTheAI.y < _minOffset_Y && _ballPositionRelativeToTheAI.x < _minOffset_X)
        {
            _characterControl.Move_Left(transform);
            _characterControl.Jump(_aiRB);
        }
        //5# get ready to attack
        else if (_distanceTO_ball > _minDistanceToBall && _ballPositionRelativeToTheAI.y > _minOffset_Y && _ballPositionRelativeToTheAI.x > _minOffset_X)
        {

        }
        //6# Head attack
        else if (_distanceTO_ball < _minDistanceToBall && _ballPositionRelativeToTheAI.y > _minOffset_Y && _ballPositionRelativeToTheAI.x > _minOffset_X)
        {
            _characterControl.Jump(_aiRB);
        }
        //7# Kick
        else if (_distanceTO_ball < _minDistanceToBall && _ballPositionRelativeToTheAI.y < _minOffset_Y && _ballPositionRelativeToTheAI.x > _minOffset_X)
        {
            _characterControl.Kick(_animator);
        }
    }

    private void FixedUpdate()
    {
        _ballPositionRelativeToTheAI = _ball.position - transform.position;
        _distanceTO_ball = _ballPositionRelativeToTheAI.magnitude;

        var distanceTO_player = (_player.position - transform.position).magnitude;
        var distanceTO_playerGoal = Math.Abs(_Player_Goal.position.x - transform.position.x);
        var distanceTO_AIGoal = Math.Abs(_AI_Goal.position.x - transform.position.x);

        _TextMeshProUGUI.text =
            $"Позиция мяча: {_ballPositionRelativeToTheAI}.\n" +
            $"Дистанция до мяча: {_distanceTO_ball}.\n" +
            $"Дистанция до игрока: {distanceTO_player}.\n" +
            $"Дистанция до своих ворот: {distanceTO_AIGoal}.\n" +
            $"Дистанция до ворот игрока: {distanceTO_playerGoal}.";
    }
}
