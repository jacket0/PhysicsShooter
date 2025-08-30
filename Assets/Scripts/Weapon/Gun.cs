using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform _gunPoint;
    [SerializeField] private float _damage;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _maxDistance;
    [SerializeField] private float _fireForce = 5;

    [Header ("Effects")]
    [SerializeField] private FireSound _fireSound;
    [SerializeField] private Transform _decal;
    [SerializeField] private float _decalOffset;

    public void RaycastShoot()
    {
        _fireSound.Fire();
        
        if (Physics.Raycast(_gunPoint.position, _gunPoint.forward, out RaycastHit hit, _maxDistance, _layerMask, QueryTriggerInteraction.Ignore))
        {
            var decal = Instantiate(_decal, hit.transform);
            decal.position = hit.point + hit.normal * _decalOffset;
            decal.LookAt(hit.point);

            Health health = hit.collider.GetComponentInParent<Health>();
            health?.DecreaseHealth(_damage);

            Rigidbody victimBody = hit.rigidbody;
            victimBody?.AddForceAtPosition(_fireForce * _gunPoint.forward, hit.point);

        }
    }
}
