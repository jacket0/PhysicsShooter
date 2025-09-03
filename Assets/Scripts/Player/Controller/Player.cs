using System;
using UnityEngine;

[RequireComponent (typeof(InputReader), typeof(PlayerMover), typeof(CameraController))]
public class Player : MonoBehaviour
{
    [SerializeField] private Gun _gun;
    
    private InputReader _inputReader;
    private PlayerMover _movement;
    private CameraController _camera;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _movement = GetComponent<PlayerMover>();
        _camera = GetComponent<CameraController>();
    }

    private void OnEnable()
    {
        _inputReader.PlayerShooted += Shoot;
        _inputReader.PlayerJumped += Jump;
    }

    private void OnDisable()
    {
        _inputReader.PlayerShooted -= Shoot;
        _inputReader.PlayerJumped -= Jump;
    }

    private void Update()
    {
        _movement.Move(_inputReader.InputDirection);
        _camera.Looking(_inputReader.MouseDirection);
    }

    private void Jump(bool isJumped)
    {
        _movement.SetJumpFlag(isJumped);
    }

    private void Shoot()
    {
        _gun.RaycastShoot();
    }
}
