using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private Transform _point_1;
    [SerializeField] private Transform _point_2;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private Transform _startPoint;

    private Vector3 _nextPoint;

    private void Start() {
        _nextPoint = _startPoint.position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _nextPoint, _speed * Time.deltaTime);

        if (transform.position == _point_1.position) {
            _nextPoint = _point_2.position;
            transform.localScale = new Vector2(-1, 1);
        } else if (transform.position == _point_2.position) {
            _nextPoint = _point_1.position;
            transform.localScale = new Vector2(1, 1);
        }
    }

}
