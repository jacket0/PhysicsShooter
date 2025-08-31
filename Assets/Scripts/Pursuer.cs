using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Pursuer : MonoBehaviour
{
    private const float Epsilon = 0.05f;

    [SerializeField] private Player _player;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _minDistance = 0.5f;

    [SerializeField] private float _maxStepHeight = 0.3f;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private Vector3 _footPosition = new Vector3(0, 0, 0);
    [SerializeField] private float _raycastLength = 1f;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 directionToPlayer = (_player.transform.position - transform.position).normalized;

        var groundHit = Physics.Raycast(_footPosition, directionToPlayer, out RaycastHit groundHitInfo, _raycastLength, _ground);
        var ladderHit = Physics.Raycast(_footPosition + new Vector3(0, _maxStepHeight, 0), directionToPlayer, out RaycastHit ledderHitInfo, _raycastLength, _ground);

        float distance = (transform.position - _player.transform.position).sqrMagnitude;

        if (distance > _minDistance)
        {
            if (!ladderHit && groundHit)
            {
                directionToPlayer.y = ledderHitInfo.point.y - transform.position.y + Epsilon;
            }

            _rigidbody.MovePosition(transform.position + directionToPlayer * _speed * Time.deltaTime);
        }
    }
}