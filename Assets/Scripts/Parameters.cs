using UnityEngine;

public class Parameters : MonoBehaviour
{
    [SerializeField] internal float _speed = .02f;
    [SerializeField] internal float _jump = 8;
    [SerializeField] internal float _force = 2.5f;
    [SerializeField] internal Vector2 _angleKick = Vector2.down * .3f;
}
