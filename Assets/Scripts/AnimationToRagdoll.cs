using System;

using System.Collections.Generic;

using UnityEngine;


public class AnimationToRagdoll : MonoBehaviour

{

	[SerializeField] private List<Rigidbody> _rigidbodies;

	[SerializeField] private Animator _animator;


    private bool _isRigging;


    private void Start()

    {

        _isRigging = false;


        DisableRagdoll();

    }


    private void Update()

    {

        if (Input.GetKeyUp(KeyCode.Space))

        {

            ChangePersonState();

        }

    }

    private void ChangePersonState()

    {

        _isRigging = !_isRigging;


        if (_isRigging)

            EnableRagdoll();

        else

            DisableRagdoll();

    }


    private void DisableRagdoll()

    {

        _animator.enabled = false;

        foreach (Rigidbody rigidbody in _rigidbodies)

            rigidbody.isKinematic = false;

    }


    private void EnableRagdoll()

    {

        _animator.enabled = true;

        foreach (Rigidbody rigidbody in _rigidbodies)

            rigidbody.isKinematic = true;

    }

}