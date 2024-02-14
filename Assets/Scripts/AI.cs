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
    private float _offCenter_X = .2f;
    private float _upperLimitKick = .2f;
    private float _rightLimitKick = .85f;
    private float _decisionMakingArea = 2.2f;
    private float _minHeightToJump = 1f;

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

        if (_ballPositionRelativeToTheAI.x >= _offCenter_X)
            Attack();
        else if (_ballPositionRelativeToTheAI.x < _offCenter_X)
            Defense();
    }

    private void Defense()
    {
        //try to catch ball
        if (_distanceTO_ball < _decisionMakingArea && _ballPositionRelativeToTheAI.y < _minHeightToJump)
        {
            _characterControl.Move_Left(transform);
            _characterControl.Jump(_aiRB);
        }
        //run back
        else if (_distanceTO_ball > _decisionMakingArea)
        {
            _characterControl.Move_Left(transform);
        }
    }

    private void Attack()
    {
        //Kick
        if (_distanceTO_ball < _decisionMakingArea && _ballPositionRelativeToTheAI.y <= _upperLimitKick && _ballPositionRelativeToTheAI.x < _rightLimitKick)
        {
            _characterControl.Move_Right(transform);
            _characterControl.Kick(_animator);
        }
        //Head attack
        else if (_distanceTO_ball < _decisionMakingArea && _ballPositionRelativeToTheAI.y > _upperLimitKick)
        {
            _characterControl.Move_Right(transform);
            _characterControl.Jump(_aiRB);
        }
        //run forward
        else if (_distanceTO_ball > _decisionMakingArea)
        {
            _characterControl.Move_Right(transform);
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
