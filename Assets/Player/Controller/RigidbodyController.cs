using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class RigidbodyController : MonoBehaviour
{
    [SerializeField] private float _speed = 10;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
            
    }
}
