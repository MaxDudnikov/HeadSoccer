using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Movement : MonoBehaviour
{
    [SerializeField] private Collider2D[] circleCollider;
    [SerializeField] private Parameters _parameters;
    private Rigidbody2D _bodyRG;
    private Animator _animator;
    internal UnityAction _kick;

    private void Start()
    {
        _bodyRG = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _bodyRG.GetContacts(circleCollider) > 0)
        {
            _bodyRG.AddForce(Vector2.up * _parameters._jump, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * _parameters._speed;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * _parameters._speed;
        }
        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetTrigger("Kick");
            _kick?.Invoke();
        }
    }
}
