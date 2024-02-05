using UnityEngine;
using UnityEngine.Events;

namespace Control
{
    public class CharacterControl : MonoBehaviour
    {
        private Parameters _parameters;
        internal UnityAction _kick;

        private void Awake()
        {
            _parameters = GetComponent<Parameters>();
        }

        internal void Move_Left(Transform transform)
        {
            transform.position += Vector3.left * _parameters._speed;
        }

        internal void Move_Right(Transform transform)
        {
            transform.position += Vector3.right * _parameters._speed;
        }

        internal void Jump(Rigidbody2D rigidbody2D)
        {
            rigidbody2D.AddForce(Vector2.up * _parameters._jump, ForceMode2D.Impulse);
        }

        internal void Kick(Animator animator)
        {
            animator.SetTrigger("Kick");
            _kick?.Invoke();
        }
    }
}
