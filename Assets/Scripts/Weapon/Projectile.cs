using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float _damage;

    private Rigidbody _rb;
    private Collider _collider;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    internal void Initialize(Collider collider)
    {
        Physics.IgnoreCollision(collider, _collider);
    }

    public void Shoot(Vector3 start, Vector3 speed)
    {
        _rb.position = start;
        _rb.linearVelocity = speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            Health health = collision.collider.GetComponentInParent<Health>();
            health?.DecreaseHealth(_damage);
        }
    }
}
