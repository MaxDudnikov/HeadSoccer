using Control;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private CharacterControl _characterControl;
    [SerializeField] private Collider2D[] _circleCollider;
    private Rigidbody2D _bodyRG;
    private Animator _animator;

    private void Start()
    {
        _bodyRG = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _bodyRG.GetContacts(_circleCollider) > 0)
        {
            _characterControl.Jump(_bodyRG);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _characterControl.Move_Right(transform);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _characterControl.Move_Left(transform);
        }
        if (Input.GetMouseButtonDown(0))
        {
            _characterControl.Kick(_animator);
        }
    }
}
