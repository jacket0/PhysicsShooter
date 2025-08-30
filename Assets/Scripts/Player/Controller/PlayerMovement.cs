using UnityEngine;

[RequireComponent (typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _strafeSpeed = 5;
    [SerializeField] private float _jumpSpeed = 5;
    [SerializeField] private float _gravityScale = 2;
    [SerializeField] private CameraController _camera;

    private CharacterController _controller;
    private Vector3 _verticalVelocity;
    private Vector3 _horizontalVelocity;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    public void Move(Vector3 direction)
    {
        Vector3 newPosition = direction.x * _camera.Right * _speed + direction.z * _camera.Forward * _strafeSpeed;

        if (_controller.isGrounded)
        {
            _verticalVelocity = (Input.GetKeyDown(KeyCode.Space)) ? Vector3.up * _jumpSpeed : Vector3.down;
            _controller.Move((newPosition + _verticalVelocity) * Time.deltaTime);
        }
        else
        {
            _horizontalVelocity = _controller.velocity;
            _horizontalVelocity.y = 0;
            _verticalVelocity += Physics.gravity * _gravityScale * Time.deltaTime;
            _controller.Move((_verticalVelocity + _horizontalVelocity) * Time.deltaTime);
        }
    }
}
