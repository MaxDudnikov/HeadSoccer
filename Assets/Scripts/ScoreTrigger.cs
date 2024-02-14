using UnityEngine;
using UnityEngine.Events;

public class ScoreTrigger : MonoBehaviour
{
    internal UnityAction _score;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            _score?.Invoke();
        }
    }
}
