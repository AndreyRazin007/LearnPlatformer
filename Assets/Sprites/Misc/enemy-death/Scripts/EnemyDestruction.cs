using UnityEngine;

public class EnemyDestruction : MonoBehaviour
{
    [SerializeField] private GameObject _deathPrefab;

    private Rigidbody2D _body;
    private Vector2 _enemyCoordinates;

    private void Start()
    {
        _body = gameObject.GetComponentInParent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            _enemyCoordinates = collision.gameObject.transform.position;
            var death = Instantiate(_deathPrefab, _enemyCoordinates, Quaternion.identity);
            _body.velocity = new Vector2(_body.position.x, _body.position.y + 2f);

            Destroy(collision.gameObject);
            Destroy(death, 0.5f);
        }
    }
}
