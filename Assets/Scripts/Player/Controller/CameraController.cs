using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private float _horizotnalSensetive = 12;
    [SerializeField] private float _verticalSensetive = 8;
    [SerializeField] private float _verticalMaxAngle = 89;
    [SerializeField] private float _verticalMinAngle = -89;

    private float _cameraAngle;
    private Transform _transform;

    public Vector3 Right {  get; private set; }
    public Vector3 Forward { get; private set; }

    private void Awake()
    {
        _transform = transform;
        _cameraAngle = _camera.localEulerAngles.x;
    }

    public void Looking(Vector3 direction)
    {
        Forward = Vector3.ProjectOnPlane(_camera.forward, Vector3.up);
        Right = Vector3.ProjectOnPlane(_camera.right, Vector3.up);

        _cameraAngle -= direction.y * _verticalSensetive;
        _cameraAngle = Mathf.Clamp(_cameraAngle, _verticalMinAngle, _verticalMaxAngle);
        _camera.localEulerAngles = _cameraAngle * Vector3.right;

        _transform.Rotate(direction.x * _horizotnalSensetive * Vector3.up);
    }
}
