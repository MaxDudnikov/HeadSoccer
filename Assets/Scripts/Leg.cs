using Control;
using UnityEngine;

public class Leg : MonoBehaviour
{
    [SerializeField] private CharacterControl _characterControl;
    [SerializeField] private Parameters _parameters;
    private Rigidbody2D _ball;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Ball")
        {
            _ball = collision.GetComponent<Rigidbody2D>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Ball")
        {
            _ball = null;
        }
    }

    private void OnEnable()
    {
        _characterControl._kick += Kick;
    }

    private void Kick()
    {
        if (_ball != null)
        {
            var position = new Vector2(transform.position.x, transform.position.y);
            var directionVector = _ball.GetComponent<Collider2D>().ClosestPoint(transform.position) - position + _parameters._angleKick;
            _ball.AddForce(directionVector * _parameters._force, ForceMode2D.Impulse);
        }
    }

    private void OnDisable()
    {
        _characterControl._kick -= Kick;
    }
}
