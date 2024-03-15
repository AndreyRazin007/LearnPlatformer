using UnityEngine;

public class PlantEnemy : MonoBehaviour {
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private float _dimention;

    private Animator _animator;

    void Start() {
        _animator = GetComponent<Animator>();
    }
}
