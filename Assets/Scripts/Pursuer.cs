using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Pursuer : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _minDistance = 0.5f;

    [SerializeField] private float _maxStepHeight = 0.3f;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private Vector3 _footPosition = new Vector3(0, 0, 0);

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 directionToPlayer = (_player.transform.position - transform.position).normalized;

        var groundHit = Physics.Raycast(_footPosition, directionToPlayer, out RaycastHit groundHitInfo, 1f, _ground);
        var ladderHit = Physics.Raycast(_footPosition + new Vector3(0, _maxStepHeight, 0), directionToPlayer, out RaycastHit ledderHitInfo, 1f, _ground);

        float distance = Vector3.Distance(transform.position, _player.transform.position);

        if (distance > _minDistance)
        {
            if (!ladderHit && groundHit)
            {
                directionToPlayer.y = ledderHitInfo.point.y - transform.position.y + 0.05f;
            }

            _rb.MovePosition(transform.position + directionToPlayer * _speed * Time.deltaTime);
        }
    }
}