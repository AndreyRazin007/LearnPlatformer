using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private Transform _spawn;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("enemy")) {
            transform.position = _spawn.transform.position;
        }
    }
}
