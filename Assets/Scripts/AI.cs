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
    private float distanceTO_ball = 0;

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

        if (transform.position.x < _ball.position.x)
        {
            _characterControl.Move_Right(transform);
        }
        else if (transform.position.x > _ball.position.x)
        {
            _characterControl.Move_Left(transform);
        }

        if (transform.position.y < _ball.position.y && distanceTO_ball < 2)
        {
            //_characterControl.Jump(_aiRB);
            _characterControl.Kick(_animator);
        }
    }

    private void FixedUpdate()
    {
        distanceTO_ball = (_ball.position - transform.position).magnitude;
        var distanceTO_player = (_player.position - transform.position).magnitude;
        var distanceTO_playerGoal = Math.Abs(_Player_Goal.position.x - transform.position.x);
        var distanceTO_AIGoal = Math.Abs(_AI_Goal.position.x - transform.position.x);
        _TextMeshProUGUI.text =
            $"Дистанция до мяча: {distanceTO_ball}.\n" +
            $"Дистанция до игрока: {distanceTO_player}.\n" +
            $"Дистанция до своих ворот: {distanceTO_AIGoal}.\n" +
            $"Дистанция до ворот игрока: {distanceTO_playerGoal}.";
    }
}
