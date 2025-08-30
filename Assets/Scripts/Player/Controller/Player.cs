using UnityEngine;

[RequireComponent (typeof(InputReader), typeof(PlayerMovement), typeof(CameraController))]
public class Player : MonoBehaviour
{
    [SerializeField] private Gun _gun;
    
    private InputReader _inputReader;
    private PlayerMovement _movement;
    private CameraController _camera;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _movement = GetComponent<PlayerMovement>();
        _camera = GetComponent<CameraController>();
    }

    private void Update()
    {
        _movement.Move(_inputReader.InputDirection);
        _camera.Looking(_inputReader.MouseDirection);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _gun.RaycastShoot();
        }
    }
}
